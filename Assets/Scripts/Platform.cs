using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _stairsHeight;
    [SerializeField] private float _stairsWidth;
    [SerializeField] private float _noOfStairs;
    [SerializeField] private Vector2 targetPos;

    [SerializeField] private bool isMovingUp;
    [SerializeField] private bool isclimbing;


    // Start is called before the first frame update
    void Start()
    {
        MoveUp();
        isclimbing = true;

    }

    // Update is called once per frame
    void Update()
    {

        if (isclimbing)
        {
            Climb();
        }



        if (_noOfStairs < 0)
        {
            isclimbing = false;
        }

    }

    public void Climb()
    {
        Vector2 newPos = Vector2.MoveTowards(transform.position, targetPos, _moveSpeed * Time.deltaTime);

        transform.position = newPos;


        if (newPos == targetPos)
        {
            if (isMovingUp)
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
        targetPos = new Vector2(transform.position.x, transform.position.y + _stairsHeight);
        isMovingUp = true;
        _noOfStairs--;
    }

    public void MoveRight()
    {
        targetPos = new Vector2(transform.position.x + _stairsWidth, transform.position.y);
        isMovingUp = false;
    }

    public void MoveLeft()
    {
        targetPos = new Vector2(transform.position.x - _stairsWidth, transform.position.y);
        isMovingUp = false;
    }
}
