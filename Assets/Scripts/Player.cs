using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour
{

    [SerializeField] private float moveSpeed;


    public int currentPlatformIndex;
    private float moveDirection;
    private Vector2 targetPos;
    private int noOfSteps;
    private bool isMovingUp;
    private Vector2 newScale;


    [SerializeField] private EnemyManager _enemyManager;
    
    [Header("Shooting")]
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private float shootingForce = 10f;
    private Bullet _prefab;
    public Transform _gunTip;

    private bool bulletShooted;

    [Header("Gun Aiming")]
    [SerializeField] private Transform _gun;
    private float _minAngle = 0;
    private float _maxAngle = 45f;
    private float _rotationSpeed = 40;
    private float currentAngle;
    private bool isAimingUp = true;



    //public Action PlayerStates;



    private void Start()
    {
        noOfSteps = -1;
        moveDirection = 1;
        currentPlatformIndex = 0;
        newScale = transform.localScale;
        StairsManager.inst.platformData = StairsManager.inst.platformPrefabs[currentPlatformIndex];

        MoveTowardsStart();

        Events.PlayerStatesAction = Movements;
        //PlayerStates = Movements;
    }

    private void Update()
    {

        Events.PlayerStates();
        
        //if (PlayerStates != null)
        //{
        //    PlayerStates.Invoke();
        //}
    }


    public void Movements()
    {
        if (noOfSteps == -1)
        {
            MoveTowardsStartPoint();

            if(Vector3.Distance(transform.position, StairsManager.inst.platformData.startPoint.position) < 0.05f)
            {
                noOfSteps++;
                isMovingUp = true;
            }
        }
        else if (noOfSteps <= StairsManager.inst.platformData.noOfStairs)
        {
            Climb();
        }
        else
        {
            MoveTowardsEndPoint();

            if(Vector3.Distance(transform.position ,StairsManager.inst.platformData.endPoint.position) < 0.05)
            {

                NextPlatformTransition();

            }
        }
    }

    private void NextPlatformTransition()
    {

        if (currentPlatformIndex < StairsManager.inst.platformPrefabs.Count)
        {
            currentPlatformIndex++;

            Events.PlayerStatesAction = Aiming;
            //PlayerStates = Aiming;
            StairsManager.inst.platformData = StairsManager.inst.platformPrefabs[currentPlatformIndex];
            MoveTowardsStart();

            noOfSteps = 0;
            newScale.x *= -1;
            moveDirection *= -1;
            transform.localScale = newScale;


            if (_enemyManager.enemy == null && _enemyManager.enemyCount >= 0)
            {
                _enemyManager.SpawnEnemy();
                

            }
            else if(_enemyManager.bossEnemy == null && _enemyManager.bossCount > 0)
            {
                _enemyManager.SpawnBoss();

            }


        }
        else
        {
            //PlayerStates = null;
            Events.PlayerStatesAction = null;
        }



    }


    private void MoveTowardsStartPoint()
    {
        transform.position = Vector3.MoveTowards(transform.position, StairsManager.inst.platformData.startPoint.position, Time.deltaTime * moveSpeed);
    }


    private void Climb()
    {
        Vector2 newPos = Vector2.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
        transform.position = newPos;

        if(Vector2.Distance(newPos,targetPos) < 0.05)
        {
            if (isMovingUp)
            {
                targetPos = transform.position + Vector3.up * StairsManager.inst.platformData.stairsHeight;
                isMovingUp = false;
                noOfSteps++;
            }
            else
            {
                targetPos = transform.position + Vector3.right * moveDirection * StairsManager.inst.platformData.stairsWidth;
                isMovingUp = true;
            }
        }
    }


    private void MoveTowardsEndPoint()
    {
        transform.position = Vector3.MoveTowards(transform.position, StairsManager.inst.platformData.endPoint.position, Time.deltaTime * moveSpeed);
    }


    private void MoveTowardsStart()
    {
        targetPos = StairsManager.inst.platformData.startPoint.position;
    }




    private void Aiming()
    {

        if (isAimingUp)
        {
            currentAngle += _rotationSpeed * Time.deltaTime;
            if (currentAngle >= _maxAngle)
            {
                currentAngle = _maxAngle;
                isAimingUp = false;
            }
        }
        else
        {
            currentAngle -= _rotationSpeed * Time.deltaTime;
            if (currentAngle <= _minAngle)
            {
                currentAngle = _minAngle;
                isAimingUp = true;
            }
        }

        _gun.localRotation = Quaternion.Euler(0f, 0f, currentAngle);

        _bulletPrefab.PlayerShoot(_gunTip, transform);
        Shoot();

    }


    private void Shoot()
    {
       
        if (Input.GetMouseButtonDown(0) && !bulletShooted)
        {
            _prefab = Instantiate(_bulletPrefab, _gunTip.position, _gunTip.rotation);
            _prefab.PlayerShoot(_gunTip, transform);
            bulletShooted = true;

        }
        else if( bulletShooted && _prefab == null) 
        {
            Events.PlayerStatesAction = Movements;
            //PlayerStates = Movements;
            bulletShooted = false;
        }
    }




    private void OnTriggerEnter2D(Collider2D collision)
    {
        Bullet bullet = collision.GetComponent<Bullet>();

        if(bullet != null)
        {
            gameObject.SetActive(false);
        }
    }



}
