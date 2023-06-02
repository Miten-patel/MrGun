using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float _playerSpeed;
    Rigidbody2D _rb;
    Action PlayerStates;


    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();

        PlayerStates += PlayerMovement;

    }

    public void FixedUpdate()
    {
        PlayerStates?.Invoke();
    }



    void PlayerMovement()
    {
        Debug.Log("MovementsOn");
        var horizontal = Input.GetAxis("Horizontal");
        _rb.velocity = new Vector2(horizontal * _playerSpeed * Time.deltaTime, _rb.velocity.y);
       
    }

    void Aiming()
    {
    
        AimingScript.inst.Aiming();
       
    }

    void EnemySpawning()
    {

    }




    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Aim"))
        {
            //isAiming = true;
            Debug.Log("Aiming");
            PlayerStates += Aiming;
            PlayerStates += ShootingScript.instance.Shoot;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Aim"))
        {
            Debug.Log("NotAiming");
            PlayerStates -= Aiming;
            PlayerStates -= ShootingScript.instance.Shoot;




        }
    }



}
