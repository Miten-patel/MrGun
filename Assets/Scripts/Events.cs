using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Events : MonoBehaviour
{
    public static Action PlayerStatesAction;

    public static Action BulletMissAction;

    public static Action BulletHitAction;



    public static void PlayerStates()
    {
        PlayerStatesAction?.Invoke();
    }


    public static void BulletMiss()
    {
        BulletMissAction?.Invoke();
    }

    public static void BulletHit()
    {
        BulletHitAction?.Invoke();
    }




}
