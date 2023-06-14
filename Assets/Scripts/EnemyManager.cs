using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{

    [SerializeField] GameObject EnemyLeftPrefab;
    [SerializeField] GameObject EnemyRightPrefab;
    [SerializeField] private float speed;
    public GameObject prefab;


    public static EnemyManager inst;

    private void Awake()
    {
        inst = this;
    }

    public void EnemySpawnLeft()
    {
        Debug.Log("left");
        Instantiate(EnemyLeftPrefab, Player.inst.platformData.EnemyPoint.position, Quaternion.identity);
    }

    public void EnemySpawnRight()
    {
        Debug.Log("Rigtht");
        Instantiate(EnemyRightPrefab, Player.inst.platformData.EnemyPoint.position, Quaternion.identity);
    }


}
