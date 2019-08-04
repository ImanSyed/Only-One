using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;


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
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void Restart()
    {
        StartCoroutine(R());
    }

    public IEnumerator R()
    {
        yield return new WaitForSeconds(2.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
