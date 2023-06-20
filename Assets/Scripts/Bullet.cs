using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float force;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private int _damage = 100;

    private Transform _playerTransform;
    private Transform _gunTip;
    private bool isCollided;


    void Start()
    {
        if (_playerTransform != null)
        {
            PlayerShoot(_gunTip, _playerTransform);
        }

        Destroy(gameObject, 3);
    }

    private void OnDisable()
    {
        if(!isCollided)
        {
            Events.BulletMiss();
        }
    }




    public void PlayerShoot(Transform _gunTip, Transform _playerTransform)
    {
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
        Enemy enemy = collision.GetComponent<Enemy>();

        if (enemy != null)
        {
            isCollided = true;

            enemy.TakeDamage(100);
            Destroy(gameObject);
        }
    

    }


}

