using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;

    public float upTime;
    public float rightTime;
    float timer;

    public bool movingup;





    void Start()
    {
        movingup = true;
        timer = 1f;


        Vector3 offset = transform.position;

        for (int i = 0; i < 15; i++)
        {
            GameObject.CreatePrimitive(PrimitiveType.Cube).transform.position = transform.position + offset;
            offset += new Vector3(0.5f, 0.5f, 0);
        }

    }

    public void FixedUpdate()
    {


        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            if (movingup)
            {
                timer = rightTime;
                movingup = false;
            }
            else
            {
                timer = upTime;
                movingup = true;
            }
        }

        PlayerMovement();

    }




    void PlayerMovement()
    {

        if (movingup)
        {
            transform.Translate(Vector2.up * Time.deltaTime * moveSpeed);
            Debug.Log("Up");
            //_rb.velocity = new Vector2(-moveSpeed, climbSpeed);
        }

        else
        {
            Debug.Log("right");
            transform.Translate(Vector2.right * Time.deltaTime * moveSpeed);
        }

        
    }









}
