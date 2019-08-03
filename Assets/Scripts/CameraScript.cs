using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField]
    float speed;

    [SerializeField]
    Transform target;

    void Update()
    {
        float interpolation = speed * Time.deltaTime;

        Vector3 pos = transform.position;
        pos.x = Mathf.Lerp(transform.position.x, target.position.x, interpolation);
        pos.y = Mathf.Lerp(transform.position.y, target.position.y, interpolation);
        transform.position = pos;
    }
}
