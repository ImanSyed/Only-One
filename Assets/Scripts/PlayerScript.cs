﻿using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    CharacterController2D controller;

    public float runSpeed = 40f;

    float horizontalMove = 0f;
    bool jump = false;

    [SerializeField]
    float health = 5;

    private void Awake()
    {
        controller = GetComponent<CharacterController2D>();
    }

    // Update is called once per frame
    void Update()
    {

        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }
    }

    void FixedUpdate()
    {
        if (controller)
        {
            if(horizontalMove != 0 && !GetComponent<Animator>().GetBool("Walking"))
            {
                GetComponent<Animator>().SetBool("Walking", true);
            }
            else
            {
                GetComponent<Animator>().SetBool("Walking", false);
            }
            // Move our character
            controller.Move(horizontalMove * Time.fixedDeltaTime, jump);
            jump = false;
        }
    }

    public void TakeDamage(float dmg)
    {
        health -= dmg;
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }
}