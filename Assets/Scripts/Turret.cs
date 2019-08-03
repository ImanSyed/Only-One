using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] Transform targetPlayer;
    public GameObject [] missle;
    public GameObject missleEmiiter;
    [SerializeField]  float misslespeed = 15.0f;
    [SerializeField] float timeDestroyed = 1.0f;
    [SerializeField] float bulletInterval = 1.0f;
    GameObject TempBullet;
    Rigidbody2D TempRigid;



    // Update is called once per frame
    void Start()
    {
       StartCoroutine(ShootProjectille());
    }

    private void Update()
    {
        Vector2 targetPos = targetPlayer.position;
        Vector2 thisPos = transform.position;
        targetPos.x = targetPos.x - thisPos.x;
        targetPos.y = targetPos.y - thisPos.y;
        float angle = Mathf.Atan2(targetPos.y, targetPos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
    
    IEnumerator ShootProjectille()
    {
        while (true)
        {
            yield return new WaitForSeconds(bulletInterval);
            TempBullet = Instantiate(missle[UnityEngine.Random.Range(0, missle.Length)], missleEmiiter.transform.position, transform.rotation);
            TempRigid = TempBullet.GetComponent<Rigidbody2D>();
            TempRigid.AddForce(transform.right * misslespeed);
            Destroy(TempBullet, timeDestroyed);
        }

    }
}
