using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float climbSpeed = 3f;

    //[SerializeField] private float newpos;

    float timer;

    //Rigidbody2D _rb;
    private bool isClimbingLeft = false;
    public bool isClimbingRight = false;


    public bool movingup;
    public bool movingRight;

    //[SerializeField] private float UpPos;

   public float _targetPosition;

    //Vector2 targetDistance = new Vector2(0,1);

    Vector2 CurrentPos;
    Vector2 UpPos;
    Vector2 RightPos;

    private bool isClimbingUp;


    Action PlayerStates;




    void Start()
    {
        movingup = true;
        timer = 1f;
        CurrentPos = transform.position;

        //UpPos = new Vector2(CurrentPos.x, CurrentPos.y + 1f);

        //RightPos = new Vector2(CurrentPos.x + 1f, CurrentPos.y);

        Debug.Log(UpPos);

        //PlayerStates += PlayerMovement;
        //isClimbingRight = true;

       



        
    }

    public void FixedUpdate()
    {
        Debug.Log("RightPos" + RightPos);
        Debug.Log("Currentpos" + CurrentPos);

        timer -= Time.fixedDeltaTime;

        if(timer < 0)
        {
            Debug.Log("timer");
            timer = 1f;
            PlayerMovement(); 
        }


        //transform.Translate(Vector2.right * Time.deltaTime * moveSpeed);
        //transform.position = Vector2.MoveTowards(transform.position,UpPos, Time.deltaTime);
        //if(Vector2.Distance (transform.position))
        //if (transform.position.y == UpPos.y)
        //{
        //    Debug.Log("Transform.y = up.y");
        //    CurrentPos = transform.position;
        //}

        //if (UpPos.y == transform.position.y)
        //{
        //    Debug.Log("move Right");
        //    transform.position = Vector2.MoveTowards(transform.position, RightPos, Time.deltaTime);
        //}

        PlayerStates?.Invoke();
    }




    

    void PlayerMovement()
    {

        if (movingup)
        {
            transform.Translate(Vector2.up * Time.deltaTime);
            Debug.Log("Up");
            //_rb.velocity = new Vector2(-moveSpeed, climbSpeed);
        }

        else
        {
            Debug.Log("right");
            transform.Translate(Vector2.right * Time.deltaTime);
        }
        //if (isClimbingUp)
        //{
        //    Debug.Log("climbing up");
        //    //_rb.velocity = new Vector2(moveSpeed, climbSpeed);
        //    //transform.position = Vector2.MoveTowards(transform.position, Vector2.up, Time.deltaTime);
        //    transform.Translate(Vector2.up * Time.deltaTime * moveSpeed);
        //}


        //if (isClimbingRight)
        //{
        //    Debug.Log("climbing right");
        //    transform.Translate(Vector2.right * Time.deltaTime * moveSpeed);

            

            //transform.position = Vector2.MoveTowards(transform.position, Vector2.right, Time.deltaTime);
        


    }


    void Aiming()
    {

        AimingScript.inst.Aiming();

    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Aim"))
        {
            PlayerStates += Aiming;
            PlayerStates += ShootingScript.instance.Shoot;
            //LeftClimb = false;
            //RightClimb = true;


        }

        if (collision.gameObject.CompareTag("Ladder"))
        {
            isClimbingUp = true;
            isClimbingRight = false;
        }

        //if (collision.gameObject.CompareTag("Stairs"))
        //{
        //    transform.position = Vector2.MoveTowards(transform.position,Vector2.up, Time.deltaTime);
        //}

 



    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Aim"))
        {
            Debug.Log("NotAiming");
            PlayerStates -= Aiming;
            PlayerStates -= ShootingScript.instance.Shoot;

        }


        if (collision.gameObject.CompareTag("Ladder"))
        {
            isClimbingUp = false;
            isClimbingRight = true;

        }

    }


    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    //if (LeftClimb == true)
    //    //{
    //    //    isClimbingLeft = true;
    //    //}

    //    //if (RightClimb == true)
    //    //{
    //    //    isClimbingRight = true;
    //    //}

    //    if (collision.gameObject.CompareTag("Ladder"))
    //    {
    //        isClimbingUp = true;
    //        isClimbingRight = false;
    //    }
    //}


    //private void OnCollisionExit2D(Collision2D collision)
    //{
    //    //if (LeftClimb == true)
    //    //{
    //    //    isClimbingLeft = false;
    //    //}

    //    if (collision.gameObject.CompareTag("Ladder"))
    //    {
    //        isClimbingUp = false;
    //        isClimbingRight = true;

    //    }
    //}







}
