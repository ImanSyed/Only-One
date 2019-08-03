﻿using UnityEngine;

public class ItemScript : MonoBehaviour
{
    public float snapValue = 1;

    bool axis, locked;

    Vector2 startPos;

    public float lockValue = 0.25f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        startPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    // Update is called once per frame
    void Update()
    {

        /*  
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 0;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        transform.position = new Vector3(Round(mousePos.x), Round(mousePos.y));
        */

        if(Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0)
        {
            if(Vector2.Distance(startPos, Input.mousePosition) >= 2f)
            {
                Invoke("Unlock", lockValue);
            }
        }

        if (!locked)
        {
            if (Input.GetAxisRaw("Mouse X") > 10000)
            {
                transform.Translate(Vector2.right * snapValue * 2);
                locked = true;
                CancelInvoke();
            }
            if (Input.GetAxisRaw("Mouse X") < -10000)
            {
                transform.Translate(Vector2.left * snapValue * 2);
                locked = true;
                CancelInvoke();

            }
            if (Input.GetAxisRaw("Mouse Y") > 10000)
            {
                transform.Translate(Vector2.up * snapValue);
                locked = true;
                CancelInvoke();

            }
            if (Input.GetAxisRaw("Mouse Y") < -10000)
            {
                transform.Translate(Vector2.down * snapValue);
                locked = true;
                CancelInvoke();

            }
        }
        Manipulation();
    }

    /*private float Round(float input)
    {
        return (snapValue * Mathf.Round(input / snapValue) + 0.5f);
    }*/

    void Unlock()
    {
        locked = false;
        startPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void Manipulation()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            axis = !axis;
        }
        if (!axis)
        {
            if (Input.GetAxisRaw("Size") > 0 && transform.localScale.x < 4.5f)
            {
                Vector3 scale = transform.localScale;
                scale.x += 0.25f;
                transform.localScale = scale;
            }
            else if (Input.GetAxisRaw("Size") < 0 && transform.localScale.x > 0.5f)
            {
                Vector3 scale = transform.localScale;
                scale.x -= 0.25f;
                transform.localScale = scale;
            }
        }
        else
        {
            if (Input.GetAxisRaw("Size") > 0 && transform.localScale.y < 4.5f)
            {
                Vector3 scale = transform.localScale;
                scale.y += 0.25f;
                transform.localScale = scale;
            }
            else if (Input.GetAxisRaw("Size") < 0 && transform.localScale.y > 0.5f)
            {
                Vector3 scale = transform.localScale;
                scale.y -= 0.25f;
                transform.localScale = scale;
            }
        }
    }
}
