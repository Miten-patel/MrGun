using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] public float _moveSpeed;
    [SerializeField] private float _startpoint;
    [SerializeField] private float _endPoint;
    [SerializeField] private float _stairsHeight;
    [SerializeField] private float _stairsWidth;
    [SerializeField] private float _noOfStairsRight;
    [SerializeField] private float _noOfStairsLeft;
    
     private Vector2 targetPos;


    [SerializeField] private bool isMovingUp;
    [SerializeField] private bool isClimbing;


    public static Platform inst;

    private void Awake()
    {
        inst = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        MoveUp();
        isClimbing = true;
    }



    // Update is called once per frame
    void Update()
    {
        if (isClimbing)
        {
            Climb();
        }

        if (_noOfStairsRight < 0 && _noOfStairsLeft < 0)
        {
            isClimbing = false;
        }
    }

    public void Climb()
    {
        Vector2 newPos = Vector2.MoveTowards(Player.inst._player.position, targetPos, _moveSpeed * Time.deltaTime);
        Player.inst._player.position = newPos;

        if (newPos == targetPos)
        {
            if (isMovingUp)
            {
                if (_noOfStairsRight > 0)
                {
                    MoveRight();
                    _noOfStairsRight--;
                }
                else if (_noOfStairsLeft > 0 && Input.GetKeyDown(KeyCode.Space))
                {
                    MoveLeft();
                    _noOfStairsLeft--;
                }
            }
            else
            {
                MoveUp();
            }
        }
    }

    public void MoveUp()
    {
        targetPos = new Vector2(Player.inst._player.position.x, Player.inst._player.position.y + _stairsHeight);
        isMovingUp = true;
    }

    public void MoveRight()
    {
        targetPos = new Vector2(Player.inst._player.position.x + _stairsWidth, Player.inst._player.position.y);
        isMovingUp = false;
    }

    public void MoveLeft()
    {
        targetPos = new Vector2(Player.inst._player.position.x - _stairsWidth, Player.inst._player.position.y);
        isMovingUp = false;
    }
}
