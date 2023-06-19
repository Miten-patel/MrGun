using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairsManager : MonoBehaviour
{
    public List<PlatformData> platformPrefabs;
    public PlatformData platformData;
    

    public static StairsManager inst;


    private void Awake()
    {
        inst = this;
    }

}
