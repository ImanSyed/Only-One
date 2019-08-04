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
            infected = false;
            GetComponent<SpriteRenderer>().color = Color.Lerp(GetComponent<SpriteRenderer>().color, Color.green, 0.15f);
            if (GetComponent<ForcefieldGenerator>())
            {
                StartCoroutine(GetComponent<ForcefieldGenerator>().PowerDown());
            }
            else
            {
                Invoke("Destroy", 2f);
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

    public void TakeDamage(float dmg)
    {
        if (dmg >= 100)
        {
            Destroy();
        }
    }
}
