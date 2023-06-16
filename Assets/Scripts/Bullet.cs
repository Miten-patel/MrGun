using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float force;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Enemy _enemy;
    private Transform _playerTransform;
    private Transform _gunTip;

    private bool isCollided;

    void Start()
    {
        PlayerShoot(_gunTip,_playerTransform);
        //rb = GetComponent<Rigidbody2D>();

        isCollided = false;
        Destroy(gameObject, 3);
    }

    private void OnDisable()
    {
        Debug.Log(isCollided + "Iscollised");

        if(!isCollided)
        {
            Events.BulletMiss?.Invoke();
        }
    }




    public void PlayerShoot(Transform _gunTip, Transform _playerTransform)
    {
        Debug.Log("PlayerSHoot");
        this._gunTip = _gunTip;
        this._playerTransform = _playerTransform;

        if (_playerTransform.localScale.x > 0)
        {
            rb.AddForce(_gunTip.right * force, ForceMode2D.Impulse);
        }

        else
        {
            rb.AddForce(_gunTip.right * -force, ForceMode2D.Impulse);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Enemy>() != null)
        {
            Debug.Log("Player Collision");
            isCollided = true;
        }
        
        if(collision.gameObject.GetComponent<Enemy>())
        {
            Debug.Log("Enemy collided");
            //_enemy._health--;
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }



    }


}

