using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class StateManager : MonoBehaviour
{
    public static StateManager instance;

   
    


    public Action PlayerStates;


    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        PlayerStates = Move;
     
    }

    // Update is called once per frame
    void Update()
    {
        PlayerStates.Invoke();
    }


    public void Move()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            PlayerStates = Player.inst.Climb;
        }
    }

    public void Aim()
    {
        AimingScript.inst.Aim();
        Shoot();
 
    }

    public void Shoot()
    {
        ShootingScript.instance.Shoot();
    }
}
