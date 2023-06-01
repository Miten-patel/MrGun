using UnityEngine;

public class ShootingScript : MonoBehaviour
{
    public GameObject _bulletPrefab;
    public GameObject _enemyBulletPrefab;
    public Transform _gunTip;
    public Transform _enemyGunTip;
    public float shootingForce = 10f;


    bool isrotating;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))  
        {
            Shoot();
        }
        if(Input.GetButtonDown("Fire2"))
        {
            ShootEnemy();
        }

    }

    void Shoot()
    {
        GameObject newProjectile = Instantiate(_bulletPrefab, _gunTip.position, _gunTip.rotation);
        Rigidbody2D projectileRb = newProjectile.GetComponent<Rigidbody2D>();

        if (projectileRb != null)
        {
            projectileRb.AddForce(_gunTip.right * shootingForce, ForceMode2D.Impulse);
        }
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
