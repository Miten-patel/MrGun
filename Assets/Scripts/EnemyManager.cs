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


    public void SpawnEnemy()
    {
        if (Player.inst.transform.localScale.x > 0)
        {
            Debug.Log("Leftspawn");
            Instantiate(EnemyLeftPrefab, StairsManager.inst.platformData.EnemyPoint.position, Quaternion.identity);
        }
        else
        {
            Instantiate(EnemyRightPrefab, StairsManager.inst.platformData.EnemyPoint.position, Quaternion.identity);
        }
    }


}
