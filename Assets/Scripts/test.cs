using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public List<GameObject> platformPrefabs;
    public float moveSpeed;

    private int currentPlatformIndex;
    private Transform playerTransform;
    private Vector2 targetPos;
    private bool isMovingUp;
    private bool isClimbing;
    private int moveDirection;
    private bool isStairsCompleted;

    private void Start()
    {
        currentPlatformIndex = 0;
        isClimbing = true;
        moveDirection = 1;
        isStairsCompleted = false;

        playerTransform = Player.inst._player;

        if (platformPrefabs.Count > 0)
        {
            MoveUpOrFinish();
        }
    }

    private void Update()
    {
        if (isClimbing)
        {
            Climb();
        }
    }

    private void Climb()
    {
        Vector2 newPos = Vector2.MoveTowards(playerTransform.position, targetPos, moveSpeed * Time.deltaTime);
        playerTransform.position = newPos;

        if (newPos == targetPos)
        {
            if (isMovingUp)
            {
                MoveRightOrFinish();
            }
            else
            {
                MoveUpOrFinish();
            }
        }
    }

    private void MoveUpOrFinish()
    {
        if (currentPlatformIndex >= platformPrefabs.Count)
        {
            isClimbing = false;
        }
        else
        {
            MoveUp();
            isMovingUp = true;
            isStairsCompleted = false;
        }
    }

    private void MoveRightOrFinish()
    {
        if (currentPlatformIndex >= platformPrefabs.Count)
        {
            isClimbing = false;
        }
        else
        {
            GameObject currentPlatformPrefab = platformPrefabs[currentPlatformIndex];
            PlatformData platformData = currentPlatformPrefab.GetComponent<PlatformData>();

            if (platformData.noOfStairs > 0)
            {
                if (isStairsCompleted)
                {
                    isClimbing = false;
                    return;
                }

                MoveRight();
                platformData.noOfStairs--;
                isStairsCompleted = platformData.noOfStairs == 0;
            }
            else
            {
                currentPlatformIndex++;
                moveDirection *= -1;

                if (currentPlatformIndex >= platformPrefabs.Count)
                {
                    isClimbing = false;
                }
                else
                {
                    MoveUp();
                    isMovingUp = true;
                    isStairsCompleted = false;
                }
            }
        }
    }

    private void MoveUp()
    {
        GameObject currentPlatformPrefab = platformPrefabs[currentPlatformIndex];
        PlatformData platformData = currentPlatformPrefab.GetComponent<PlatformData>();
        targetPos = playerTransform.position + Vector3.up * platformData.stairsHeight;
    }

    private void MoveRight()
    {
        GameObject currentPlatformPrefab = platformPrefabs[currentPlatformIndex];
        PlatformData platformData = currentPlatformPrefab.GetComponent<PlatformData>();
        targetPos = playerTransform.position + Vector3.right * moveDirection * platformData.stairsWidth;
        isMovingUp = false;
    }

}
