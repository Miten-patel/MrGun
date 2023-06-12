using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformData : MonoBehaviour
{
    public float stairsHeight;
    public float stairsWidth;
    public float noOfStairs;
    public Transform startPoint;
    public Transform endPoint;


    public static PlatformData inst;

    private void Awake()
    {
        inst = this;
    }


}
