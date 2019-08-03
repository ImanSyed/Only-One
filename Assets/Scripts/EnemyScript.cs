using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public bool infected;

    private void Update()
    {
        if(infected && GetComponent<SpriteRenderer>().color != Color.green)
        {
            GetComponent<SpriteRenderer>().color = Color.Lerp(GetComponent<SpriteRenderer>().color, Color.green, 0.1f);
        }
    }
}
