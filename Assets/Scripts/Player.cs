using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{


    public List<PlatformData> platformPrefabs;
    public PlatformData platformData;
    private int currentPlatformIndex;
    private float moveDirection;
    private Vector2 targetPos;
    private int noOfSteps;
    public bool isMovingUp;
    private Vector2 newScale;

    

    [SerializeField] private float moveSpeed;

    public static Player inst;

    private void Awake()
    {
        inst = this;
    }

    void Start()
    {
        noOfSteps = -1;
        moveDirection = 1;
        currentPlatformIndex = 0;
        newScale = transform.localScale;
        platformData = platformPrefabs[currentPlatformIndex];


        MoveTowardsStart();

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (currentPlatformIndex < platformPrefabs.Count)
            {
                StateManager.instance.PlayerStates = Movements;
            }
        }


        Debug.Log(newScale);

    }

    public void Movements()
    {

        if (noOfSteps == -1)
        {

            transform.position = Vector3.MoveTowards(transform.position, platformData.startPoint.position, Time.deltaTime * moveSpeed);

            if (transform.position == platformData.startPoint.position)
            {
                Debug.Log("Player = startpoint");
                noOfSteps++;
                isMovingUp = true;
            }
        }
        else if (noOfSteps <= platformData.noOfStairs)
        {
            Climb();
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, platformData.endPoint.position, Time.deltaTime * moveSpeed);

            if (transform.position == platformData.endPoint.position)
            {
                currentPlatformIndex++;

              
                if (currentPlatformIndex < platformPrefabs.Count)
                {
                    platformData = platformPrefabs[currentPlatformIndex];
                }
                else
                {
                    StateManager.instance.PlayerStates = null;
                }

                    MoveTowardsStart();
                    noOfSteps = 0;
                    newScale.x *= -1;
                    moveDirection *= -1;
                    transform.localScale = newScale;
                    StateManager.instance.PlayerStates = StateManager.instance.Aim;
                    Enemy.inst.EnemySpawnRight();


            }

        }

    }

    public void Climb()
    {

        Vector2 newPos = Vector2.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
        transform.position = newPos;


        if (newPos == targetPos)
        {
            if (isMovingUp)
            {
                targetPos = transform.position + Vector3.up * platformData.stairsHeight;
                isMovingUp = false;
                noOfSteps++;
            }
            else
            {
                targetPos = transform.position + Vector3.right * moveDirection * platformData.stairsWidth;
                isMovingUp = true;
            }
        }
    }

    public void MoveTowardsStart()
    {
        targetPos = platformData.startPoint.position;
    }
}
