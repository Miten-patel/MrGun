using System.Collections.Generic;
using UnityEngine;

public class Levels : MonoBehaviour
{
    public List<GameObject> platformPrefabs;
    public float moveSpeed;

    private int currentPlatformIndex;
    private Vector2 targetPos;
    private bool isMovingUp;
    private bool isClimbing;
    //private Vector3 initialPlayerScale;
    private float moveDirection;

    private void Start()
    {


         

        currentPlatformIndex = 0;
        isMovingUp = true;
        isClimbing = true;
        moveDirection = 1;

        if (platformPrefabs.Count > 0)
        {
            SetupPlatform();
        }


    }

    private void Update()
    {
        if (isClimbing)
        {
            Climb();
        }
    }

    public void Climb()
    {
        Vector2 newPos = Vector2.MoveTowards(Player.inst._player.position, targetPos, moveSpeed * Time.deltaTime);
        Player.inst._player.position = newPos;

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

    public void MoveUpOrFinish()
    {
        if (currentPlatformIndex >= platformPrefabs.Count)
        {

            isClimbing = false;
            return;
        }

        MoveUp();
        isMovingUp = true;
    }

    public void MoveRightOrFinish()
    {
        GameObject currentPlatformPrefab = platformPrefabs[currentPlatformIndex];
        PlatformData platformData = currentPlatformPrefab.GetComponent<PlatformData>();

        if (platformData.noOfStairs > 0)
        {
            MoveRight();
            platformData.noOfStairs--;
        }
        else
        {
            //isClimbing = false;
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
            }
        }
    }







    public void MoveUp()
    {
        targetPos = new Vector2(Player.inst._player.position.x, Player.inst._player.position.y + platformPrefabs[currentPlatformIndex].GetComponent<PlatformData>().stairsHeight);
    }

    public void MoveRight()
    {
        targetPos = new Vector2(Player.inst._player.position.x + moveDirection * platformPrefabs[currentPlatformIndex].GetComponent<PlatformData>().stairsWidth, Player.inst._player.position.y);
        isMovingUp = false;
    }

    private void SetupPlatform()
    {
        //GameObject currentPlatformPrefab = platformPrefabs[currentPlatformIndex];
        //PlatformData platformData = currentPlatformPrefab.GetComponent<PlatformData>();
        MoveRightOrFinish();
    }
}
