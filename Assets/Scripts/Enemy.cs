using UnityEngine;
using System;

public class Enemy : MonoBehaviour
{

    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private float shootingForce = 10f;
    [SerializeField] private bool BulletShooted;
    [SerializeField] private Transform _gun;
    [SerializeField] private EnemyManager enemyManager;
    public Transform _gunTip;
    public float _health = 100;


    private Vector2 targetPos;

    [Range(3,10)]
    [SerializeField] private float moveSpeed;
    private int noOfSteps;
    private bool isMovingUp;
    private Vector2 newScale;
    private float moveDirection;


    public Player player;


    private int enemyIndex;

    public bool ismoving;
    private PlatformData enemyPlatformData;


    public Action EnemyMoveAction;
    public Action ClimbMovementAction;

    private void Start()
    {
        noOfSteps = -1;
        moveDirection = -1;
        newScale = transform.localScale;

        player = FindAnyObjectByType<Player>();
        enemyIndex = player.currentPlatformIndex;
        enemyPlatformData = StairsManager.inst.platformPrefabs[enemyIndex + 1];



    }

    void Update()
    {
        EnemyMoveAction?.Invoke();

        ClimbMovementAction?.Invoke();


    }

    private void OnEnable()
    {
        Events.BulletMissAction += PointGunAtPlayer;
        EnemyMoveAction += EnemyMove; 
    }




    public void EnemyMove()
    {
        StairsManager.inst.platformData = StairsManager.inst.platformPrefabs[enemyIndex];


        transform.position = Vector3.MoveTowards(transform.position, StairsManager.inst.platformData.endPoint.position, Time.deltaTime * 3);

        if (Vector3.Distance(transform.position, StairsManager.inst.platformData.endPoint.position) < 0.05f)
        {


            EnemyMoveAction -= EnemyMove;

        }


    }


    public void TakeDamage(int damage)
    {
        _health -= damage;

        if (_health <= 0)
        {
            Debug.Log("die");
            Die();
        }
        else
        {
            //isMovingUp = true;
            MoveTowardsStart();

            ClimbMovementAction = EnemyMovements;

        }

    }


    private void Die()
    {
        Destroy(gameObject);
    }

    public void moveEnemy()
    {

        MoveTowardsStartPoint();
    }


    public void EnemyMovements()
    {
        Debug.Log("EnemyMovement");

        if (noOfSteps == -1)
        {

            Debug.Log("== -1");
            MoveTowardsStartPoint();

            //if (transform.position == StairsManager.inst.platformData.startPoint.position)
            if (Vector3.Distance(transform.position, enemyPlatformData.startPoint.position) < 0.05f)
            {

                Debug.Log("transform ====== start");
                noOfSteps++;
                isMovingUp = true;
            }
        }

        if ((noOfSteps >= 0) && noOfSteps <= enemyPlatformData.noOfStairs)
        {
            EnemyClimb();
        }
        else
        {
            MoveTowardsEndPoint();

            if (transform.position == enemyPlatformData.endPoint.position)
            {

                NextPlatformTransition();

            }
        }
    }

    private void NextPlatformTransition()
    {

        if (enemyIndex < StairsManager.inst.platformPrefabs.Count)
        {
            enemyIndex++;

            enemyPlatformData = StairsManager.inst.platformPrefabs[enemyIndex + 1];

            //PlayerStates = Aiming;
            MoveTowardsStart();

            noOfSteps = 0;
            newScale.x *= -1;
            moveDirection *= -1;
            transform.localScale = newScale;


            //if (_enemyManager.enemy == null && _enemyManager.enemyCount >= 0)
            //{
            //    _enemyManager.SpawnEnemy();


            //}
            //else if (_enemyManager.bossEnemy == null && _enemyManager.bossCount > 0)
            //{
            //    _enemyManager.SpawnBoss();

            //}


        }
        else
        {
            //PlayerStates = null;
        }



    }



    private void MoveTowardsStartPoint()
    {
        transform.position = Vector3.MoveTowards(transform.position, enemyPlatformData.startPoint.position, Time.deltaTime * moveSpeed);
    }


    private void EnemyClimb()
    {

        Vector2 newPos = Vector2.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
        transform.position = newPos;

        if (newPos == targetPos)
        {
            if (isMovingUp)
            {
                targetPos = transform.position + Vector3.up * enemyPlatformData.stairsHeight;
                isMovingUp = false;
                noOfSteps++;
            }
            else
            {
                targetPos = transform.position + Vector3.right * moveDirection * enemyPlatformData.stairsWidth;
                isMovingUp = true;
            }
        }
    }


    private void MoveTowardsEndPoint()
    {

        transform.position = Vector3.MoveTowards(transform.position, enemyPlatformData.endPoint.position, Time.deltaTime * moveSpeed);
    }


    private void MoveTowardsStart()
    {
        Debug.Log("movetowards Start");

        targetPos = enemyPlatformData.startPoint.position;
    }









    public  void PointGunAtPlayer()
    {
        Debug.Log("gunPointed");
        Player player =  FindAnyObjectByType<Player>();

        Vector3 playerPos = player.transform.position;
        Vector3 direction = playerPos - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.Euler(0f, 0f, angle);

        _gun.rotation = rotation;

        Shoot();

    }



    public void Shoot()
    {
        if (!BulletShooted)
        {

            Bullet newProjectile = Instantiate(_bulletPrefab, _gunTip.position, _gunTip.rotation);
            BulletShooted = true;

            Rigidbody2D projectileRb = newProjectile.GetComponent<Rigidbody2D>();

            if (projectileRb != null && transform.localScale.x > 0f)
            {
                Debug.Log("positive Force");
                projectileRb.AddForce(_gunTip.right * shootingForce, ForceMode2D.Impulse);
                BulletShooted = true;
            }

            else
            {
                Debug.Log("negative Force");
                projectileRb.AddForce(_gunTip.right * -shootingForce, ForceMode2D.Impulse);
                BulletShooted = true;

            }
        }

    }




    private void OnDisable()
    {
        Events.BulletMissAction -= PointGunAtPlayer;
        EnemyMoveAction -= EnemyMove;
    }
    


}
