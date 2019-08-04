using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class End : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerScript>().shrink = true;
            StartCoroutine(EndIt());
        }
    }

    IEnumerator EndIt()
    {
        yield return new WaitForSeconds(5);
        Application.Quit();
    }
}
