using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] GameObject EnemyLeftPrefab;
    [SerializeField] GameObject EnemyRightPrefab;
    [SerializeField] private float speed;
    public GameObject prefab;


    public static Enemy inst;

    private void Awake()
    {
        inst = this;
    }

    private void Update()
    {
        
    }

    public void EnemySpawnLeft()
    {
        Instantiate(EnemyLeftPrefab, Player.inst.platformData.EnemyPoint.position, Quaternion.identity);
    }

    public void EnemySpawnRight()
    {
        GameObject EnemyPrefab = Instantiate(EnemyRightPrefab, Player.inst.platformData.EnemyPoint.position, Quaternion.identity);
        EnemyPrefab = prefab;
    }

    //public void MoveEnemy()
    //{
    //    Debug.Log("Move Enemy");
    //    EnemyLeftPrefab.transform.position = Vector3.MoveTowards(EnemyLeftPrefab.transform.position, Player.inst.platformData.endPoint.position, Time.deltaTime * speed);
    //    EnemyRightPrefab.transform.position = Vector3.MoveTowards(EnemyRightPrefab.transform.position, Player.inst.platformData.endPoint.position, Time.deltaTime * speed);
    //}


}
