using UnityEngine;

public class DamageScript : MonoBehaviour
{
    public float damage;

    public bool bullet;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerScript>())
        {
            collision.gameObject.GetComponent<PlayerScript>().TakeDamage(damage);
            if (bullet)
            {
                Destroy(gameObject);
            }
        }
        if (collision.gameObject.GetComponent<ItemScript>())
        {
            collision.gameObject.GetComponent<ItemScript>().TakeDamage(damage);
            if (bullet)
            {
                Destroy(gameObject);
            }
        }
        if (collision.gameObject.GetComponent<EnemyScript>())
        {
            collision.gameObject.GetComponent<EnemyScript>().TakeDamage(damage);
            if (bullet)
            {
                Destroy(gameObject);
            }
        }
    }
}
