using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] Transform targetPlayer;
    [SerializeField] Transform objectToPan;
    public GameObject [] missle;
    public GameObject missleEmiiter;
    [SerializeField]  float misslespeed = -15.0f;
    [SerializeField] float timeDestroyed = 1.0f;
    [SerializeField] float bulletInterval = 1.0f;
    GameObject TempBullet;
    Rigidbody2D TempRigid;



    // Update is called once per frame
    void Start()
    {
       StartCoroutine(ShootProjectille());
    }

     IEnumerator ShootProjectille()
    {
        while (true)
        {
            TempBullet = Instantiate(missle[UnityEngine.Random.Range(0, missle.Length)], missleEmiiter.transform.position, missleEmiiter.transform.rotation);
            TempRigid = TempBullet.GetComponent<Rigidbody2D>();
            TempRigid.AddForce(Vector2.right * misslespeed);
            yield return new WaitForSeconds(bulletInterval);
            Destroy(TempBullet, timeDestroyed);
        }

    }
}
