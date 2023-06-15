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

    //Shooting
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private float shootingForce = 10f;
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
                currentPlatformIndex++;

                if (currentPlatformIndex < StairsManager.inst.platformPrefabs.Count)
                {
                    StairsManager.inst.platformData = StairsManager.inst.platformPrefabs[currentPlatformIndex];
                }
                else
                {
                    PlayerStates = null;
                }

                MoveTowardsStart();

                noOfSteps = 0;
                newScale.x *= -1;
                moveDirection *= -1;
                transform.localScale = newScale;
                PlayerStates = Aiming;
                bulletShooted = false;

                EnemyManager.inst.SpawnEnemy();

            }
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

        Shoot();

    }


    private void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && bulletShooted == false)
        {
            Instantiate(_bulletPrefab, _gunTip.position, Quaternion.identity);
            bulletShooted = true;
        }
    }

}
