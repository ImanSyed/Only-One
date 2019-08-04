using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField]
    float speed;

    [SerializeField]
    Transform target;

    void Update()
    {
        if (target)
        {
            float interpolation = speed * Time.deltaTime;

            Vector3 pos = transform.position;
            pos.x = Mathf.Lerp(transform.position.x, target.position.x, interpolation);
            pos.y = Mathf.Lerp(transform.position.y, target.position.y - 1f, interpolation);
            transform.position = pos;
        }
    }
}
