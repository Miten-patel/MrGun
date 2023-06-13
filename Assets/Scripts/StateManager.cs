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

    void Start()
    {
        PlayerStates = Move; 
    }

    void Update()
    {
        if(PlayerStates != null)
        {     
            PlayerStates.Invoke();
        }
    }


    public void Move()
    {
        PlayerStates = Player.inst.Movements;
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
