using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class StateManager : MonoBehaviour
{

    Action PlayerStates;

    // Start is called before the first frame update
    void Start()
    {
        PlayerStates += Move;
        PlayerStates += Aim;
        PlayerStates += Shoot;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerStates.Invoke();
    }


    public void Move()
    {
        
    }

    public void Aim()
    {
        AimingScript.inst.Aim();
    }

    public void Shoot()
    {
        ShootingScript.instance.Shoot();
    }
}
