using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public bool infected;

    private void Update()
    {
        if(infected && GetComponent<SpriteRenderer>().color != Color.green)
        {
            Invoke("Destroy", 2f);
            GetComponent<SpriteRenderer>().color = Color.Lerp(GetComponent<SpriteRenderer>().color, Color.green, 0.01f);
        }
    }

    void Destroy()
    {
        Destroy(gameObject);
    }
}
