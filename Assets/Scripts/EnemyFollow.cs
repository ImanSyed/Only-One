using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    [SerializeField]
    float speed;

    [SerializeField]
    Transform target;

    [SerializeField]
    float distance;

    bool follow;

    void Update()
    {
        if (target && follow && Vector2.Distance(target.transform.position, transform.position) > distance)
        {
            float interpolation = speed * Time.deltaTime;

            Vector3 pos = transform.position;
            pos.x = Mathf.Lerp(transform.position.x, target.position.x, interpolation);
            pos.y = Mathf.Lerp(transform.position.y, target.position.y, interpolation);
            transform.position = pos;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !follow)
        {
            follow = true;
            if (GetComponentInChildren<Turret>())
            {
                GetComponentInChildren<Turret>().enabled = true;
            }
        }
    }
}
