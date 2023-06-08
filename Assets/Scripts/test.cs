using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
     private float _stairsHeight;
     private float _stairsWidth;
    [SerializeField] private List<PlatformData> _platforms; 

    private int _currentPlatformIndex;
    private Vector2 _targetPos;
    private bool _isMovingUp;
    private bool _isClimbing;

    void Start()
    {
        _currentPlatformIndex = 0;
        _isMovingUp = true;
        _isClimbing = true;

        if (_platforms.Count > 0)
        {
            SetupPlatform(_platforms[_currentPlatformIndex]);
        }
    }

    void Update()
    {
        if (_isClimbing)
        {
            Climb();
        }
    }

    public void Climb()
    {
        Vector2 newPos = Vector2.MoveTowards(Player.inst._player.position, _targetPos, _moveSpeed * Time.deltaTime);
        Player.inst._player.position = newPos;

        if (newPos == _targetPos)
        {
            if (_isMovingUp)
            {
                if (_currentPlatformIndex < _platforms.Count)
                {
                    PlatformData currentPlatform = _platforms[_currentPlatformIndex];

                    if (currentPlatform.noOfStairsRight > 0)
                    {
                        MoveRight();
                        currentPlatform.noOfStairsRight--;
                    }
                    else if (currentPlatform.noOfStairsLeft > 0)
                    {
                        MoveLeft();
                        currentPlatform.noOfStairsLeft--;
                    }
                    else
                    {
                        
                        _currentPlatformIndex++;

                        if (_currentPlatformIndex < _platforms.Count)
                        {
                            SetupPlatform(_platforms[_currentPlatformIndex]);
                        }
                        else
                        {
                            
                            _isClimbing = false;
                        }
                    }
                }
                else
                {
                   
                    _isClimbing = false;
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
        _targetPos = new Vector2(Player.inst._player.position.x, Player.inst._player.position.y + _stairsHeight);
        _isMovingUp = true;
    }

    public void MoveRight()
    {
        _targetPos = new Vector2(Player.inst._player.position.x + _stairsWidth, Player.inst._player.position.y);
        _isMovingUp = false;
    }

    public void MoveLeft()
    {
        _targetPos = new Vector2(Player.inst._player.position.x - _stairsWidth, Player.inst._player.position.y);
        _isMovingUp = false;
    }

    private void SetupPlatform(PlatformData platformData)
    {
        _targetPos = Player.inst._player.position; 
        _isMovingUp = true; 
        _stairsHeight = platformData.stairsHeight;
        _stairsWidth = platformData.stairsWidth;

        if (platformData.noOfStairsRight > 0)
        {
            MoveRight();
            platformData.noOfStairsRight--;
        }
        else if (platformData.noOfStairsLeft > 0)
        {
            MoveLeft();
            platformData.noOfStairsLeft--;
        }
    }
}

[System.Serializable]
public class PlatformData
{
    public float stairsHeight;
    public float stairsWidth;
    public int noOfStairsRight;
    public int noOfStairsLeft;
}