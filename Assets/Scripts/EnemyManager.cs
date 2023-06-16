using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{

    [SerializeField] GameObject EnemyLeftPrefab;
    [SerializeField] GameObject EnemyRightPrefab;
    [SerializeField] private float speed;

    public GameObject prefab;




    public void SpawnEnemy()
    {
        Debug.Log("Spawning");
        if (Player.inst.transform.localScale.x > 0)
        {
            Debug.Log("Leftspawn");
            Instantiate(EnemyLeftPrefab, StairsManager.inst.platformData.EnemyPoint.position, Quaternion.identity);
        }
        else
        {
            Debug.Log("Right Spawn");
            Instantiate(EnemyRightPrefab, StairsManager.inst.platformData.EnemyPoint.position, Quaternion.identity);
        }
    }


}
