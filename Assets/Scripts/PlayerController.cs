using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float _playerSpeed;
    Rigidbody2D _rb;


    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        PlayerMovement();
    }

    public void PlayerMovement()
    {
        var horizontal = Input.GetAxis("Horizontal");
        _rb.velocity = new Vector2(horizontal * _playerSpeed * Time.deltaTime, _rb.velocity.y);
       
    }

}
