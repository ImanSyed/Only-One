using UnityEngine;
using System.Collections;

public class ForcefieldGenerator : MonoBehaviour
{
    [SerializeField] GameObject[] forcefields;
    [SerializeField] Sprite unlocked;

    public IEnumerator PowerDown()
    {
        yield return new WaitForSeconds(1.5f);
        GetComponent<SpriteRenderer>().sprite = unlocked;
        GetComponent<SpriteRenderer>().color = Color.white;
        foreach(GameObject ff in forcefields)
        {
            ff.GetComponent<Animator>().SetTrigger("Shutdown");
            ff.GetComponent<Collider2D>().enabled = false;
        }
    }
}
