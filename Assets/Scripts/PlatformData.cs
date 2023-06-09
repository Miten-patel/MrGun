using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformData : MonoBehaviour
{
    public float stairsHeight;
    public float stairsWidth;
    public float noOfStairs;
    public float _stairsHeight;


    private void Start()
    {
       _stairsHeight = noOfStairs * stairsHeight;

    }

}
