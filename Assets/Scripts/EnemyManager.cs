using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{

    [SerializeField] Enemy EnemyLeftPrefab;
    [SerializeField] Enemy EnemyRightPrefab;
    [SerializeField] Enemy BossLeftPrefab;
    [SerializeField] Enemy BossRightPrefab;
    [SerializeField] private float speed;
    [SerializeField] Player _player;
    public int enemyCount = 4;
    public int bossCount = 1;
    public Enemy enemy;
    public Enemy bossEnemy;

    

    public void SpawnEnemy()
    {
        if (_player.transform.localScale.x > 0)
        {
            enemy = Instantiate(EnemyLeftPrefab, StairsManager.inst.platformData.EnemyPoint.position, Quaternion.identity);
            enemyCount--;
            
        }
        else
        {
            enemy = Instantiate(EnemyRightPrefab, StairsManager.inst.platformData.EnemyPoint.position, Quaternion.identity);
            enemyCount--;
        }
    }

    public void SpawnBoss()
    {
        if (_player.transform.localScale.x > 0)
        {
            bossEnemy = Instantiate(BossLeftPrefab, StairsManager.inst.platformData.EnemyPoint.position, Quaternion.identity);
            bossCount--;

        }
        else
        {
            bossEnemy = Instantiate(BossRightPrefab, StairsManager.inst.platformData.EnemyPoint.position, Quaternion.identity);
            bossCount--;
        }
    }


}
