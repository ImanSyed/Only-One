using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public bool infected;

    [SerializeField]
    GameObject explosionEffect;


    private void Update()
    {
        if(infected && GetComponent<SpriteRenderer>().color != Color.green)
        {
            Invoke("Destroy", 2f);
            GetComponent<SpriteRenderer>().color = Color.Lerp(GetComponent<SpriteRenderer>().color, Color.green, 0.01f);
            if (GetComponent<ForcefieldGenerator>())
            {
                StartCoroutine(GetComponent<ForcefieldGenerator>().PowerDown());
            }
        }
    }

    void Destroy()
    {
        if (explosionEffect)
        {
            Instantiate(explosionEffect, transform.position, transform.rotation);
        }
        Destroy(gameObject);
    }
}
