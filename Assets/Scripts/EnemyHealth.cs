using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int hitpoints = 3;
    [SerializeField] EnemyTypes type;
    bool isDead = false;

    public bool IsDead()
    {
        return isDead;
    }

    public void TakeDameage(EnemyTypes types, int damage)
    {
        //if player type equals enemy type
        if(type == types)
        {
            hitpoints -= damage;
            if (hitpoints <= 0)
            {
                Destroy(this.gameObject);
            }
        }
    }


}
