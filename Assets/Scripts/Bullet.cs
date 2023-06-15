using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float force;
    private Rigidbody2D rb;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        PlayerShoot();
    }


    public void PlayerShoot()
    {
        if (Player.inst.transform.localScale.x > 0)
        {
            rb.AddForce(Player.inst._gunTip.right * force, ForceMode2D.Impulse);
        }

        else
        {
            rb.AddForce(Player.inst._gunTip.right * -force, ForceMode2D.Impulse);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<Enemy>())
        {
            Debug.Log("Enemy collided");
            Enemy.Inst._health--;
        }
    }


}

