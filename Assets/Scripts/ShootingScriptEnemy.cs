using UnityEngine;

public class ShootingScriptEnemy : MonoBehaviour
{
    public GameObject _enemyBulletPrefab;
    public Transform _enemyGunTip;
    public float shootingForce = 10f;


    bool isrotating;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire2"))
        {
            ShootEnemy();
        }

        transform.position = Vector3.MoveTowards(transform.position, Player.inst.platformData.endPoint.position, Time.deltaTime * 3);

    }

    void ShootEnemy()
    {
        GameObject Projectile = Instantiate(_enemyBulletPrefab, _enemyGunTip.position, _enemyGunTip.rotation);
        Rigidbody2D projectileRigidbody = Projectile.GetComponent<Rigidbody2D>();

        if(projectileRigidbody != null)
        {
            projectileRigidbody.AddForce(_enemyGunTip.right * shootingForce, ForceMode2D.Impulse);
        }
    }

 
}
