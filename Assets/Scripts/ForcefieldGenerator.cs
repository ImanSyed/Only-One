using UnityEngine;
using System.Collections;

public class ForcefieldGenerator : MonoBehaviour
{
    public GameObject forcefield;

    public IEnumerator PowerDown()
    {
        yield return new WaitForSeconds(1.9f);
        Destroy(forcefield);
    }
}
