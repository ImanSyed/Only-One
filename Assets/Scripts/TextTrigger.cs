using UnityEngine;
using UnityEngine.UI;

public class TextTrigger : MonoBehaviour
{
    [SerializeField]
    string t;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            FindObjectOfType<Text>().text = t;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            FindObjectOfType<Text>().text = "";
        }
    }
}
