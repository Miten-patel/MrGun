using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour
{

    [SerializeField] private float moveSpeed;


    private int currentPlatformIndex;
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

    //Rotation

    [SerializeField] private Transform _gun;
    private float _minAngle = 0;
    private float _maxAngle = 45f;
    private float _rotationSpeed = 40;
    private float currentAngle;
    private bool isAimingUp = true;
    
    //Action
    public Action PlayerStates;
    //public Action _Enemy;


    //Instance
    public static Player inst;


    private void Awake()
    {
        inst = this;
    }



    private void Start()
    {
        noOfSteps = -1;
        moveDirection = 1;
        currentPlatformIndex = 0;
        newScale = transform.localScale;
        StairsManager.inst.platformData = StairsManager.inst.platformPrefabs[currentPlatformIndex];

        MoveTowardsStart();


        PlayerStates = Movements;
    }

    private void Update()
    {

       
        if (PlayerStates != null)
        {
            PlayerStates.Invoke();
        }
    }


    public void Movements()
    {
        Debug.Log("Movements");
        if (noOfSteps == -1)
        {
            MoveTowardsStartPoint();

            if (transform.position == StairsManager.inst.platformData.startPoint.position)
            {
                Debug.Log("Player = startpoint");
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

            if (transform.position == StairsManager.inst.platformData.endPoint.position)
            {

                NextPlatformTransition();

            }
        }
    }

    private void NextPlatformTransition()
    {
        currentPlatformIndex++;

        if (currentPlatformIndex < StairsManager.inst.platformPrefabs.Count)
        {
            
            PlayerStates = Aiming;
            StairsManager.inst.platformData = StairsManager.inst.platformPrefabs[currentPlatformIndex];
            MoveTowardsStart();

            noOfSteps = 0;
            newScale.x *= -1;
            moveDirection *= -1;
            transform.localScale = newScale;

            _enemyManager.SpawnEnemy();
        }
        else
        {
            Debug.Log("NUll");
            PlayerStates = null;
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

        if (newPos == targetPos)
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
            PlayerStates = Movements;
            bulletShooted = false;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<Bullet>())
        {
            gameObject.SetActive(false);
        }
    }



}
