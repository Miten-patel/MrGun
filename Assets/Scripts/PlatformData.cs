using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformData : MonoBehaviour
{
    //public float moveSpeed;

    public float stairsHeight;
    public float stairsWidth;
    public float noOfStairs;
    public Transform startPoint;
    public Transform endPoint;
    public Transform EnemyPoint;


    private void Awake()
    {
        startPoint = gameObject.GetComponentInChildren<Transform>().GetChild(0);
        endPoint = gameObject.GetComponentInChildren<Transform>().GetChild(1);
        EnemyPoint = gameObject.GetComponentInChildren<Transform>().GetChild(2);
    }

}
