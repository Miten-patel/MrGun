using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairsManager : MonoBehaviour
{
    //public List<PlatformData> platformPrefabs;
    //public PlatformData platformData;
    //public int currentPlatformIndex;


    public static StairsManager inst;


    private void Awake()
    {
        inst = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        //platformData = platformPrefabs[currentPlatformIndex];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
