using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    [SerializeField] public Transform _player;

    public float moveSpeed;

    private Vector2 targetPos;



    public float noOfSteps;
    private int moveDirection;
    public bool isMovingRight;
    public bool isClimbing;
    public bool isClimbed;


    public static Player inst;

    private void Awake()
    {
        inst = this;
    }

    // Start is called before the first frame update
    void Start()
    {

        noOfSteps = -1;
        moveDirection = 1;
        //MoveUp();

    }

    // Update is called once per frame
    void Update()
    {
  


        //if (noOfSteps == -1)
        //{
        //    transform.position = Vector3.MoveTowards(transform.position, PlatformData.inst.startPoint.position, Time.deltaTime * moveSpeed);

        //}


        //if (PlatformData.inst.startPoint.position.x == transform.position.x)
        //{
        //    Debug.Log("transform = startpos");
        //    //noOfSteps++;
        //    isClimbing = true;
        //}


        //if (noOfSteps <= PlatformData.inst.noOfStairs && isClimbing == true)
        //{
        //    Debug.Log("climbing");
        //    isClimbed = true;
        //}
        //else
        //{
        //    Debug.Log("Endpoint");
        //    transform.position = Vector3.MoveTowards(transform.position, PlatformData.inst.endPoint.position, Time.deltaTime * moveSpeed);
        //    isClimbed = false;
        //}

    }

    public void Climb()
    {
        Vector2 newPos = Vector2.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);

        transform.position = newPos;

        if (newPos == targetPos)
        {
            if (isMovingRight)
            {
                MoveRight();
            }
            else
            {
                MoveUp();
            }
        }

    }

    public void MoveUp()
    {
        targetPos = transform.position + Vector3.up * PlatformData.inst.stairsHeight;
        isMovingRight = true;

    }

    public void MoveRight()
    {
        targetPos = transform.position + Vector3.right * moveDirection * PlatformData.inst.stairsWidth;
        isMovingRight = false;
        noOfSteps++;
    }
}
