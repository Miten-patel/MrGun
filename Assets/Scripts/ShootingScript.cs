using UnityEngine;

public class ShootingScript : MonoBehaviour
{
    public static ShootingScript instance;

    public GameObject _bulletPrefab;
    public Transform _gunTip;
    public float shootingForce = 10f;





    bool isrotating;
    // Update is called once per frame

    private void Awake()
    {
        instance = this;
    }

    void Update()
    {
        //if (Input.GetButtonDown("Fire1"))  
        //{
        //    Shoot();
        //}
 

    }

    public void Shoot()
    {

        if (Input.GetButtonDown("Fire1"))
        {

        GameObject newProjectile = Instantiate(_bulletPrefab, _gunTip.position, _gunTip.rotation);
        Rigidbody2D projectileRb = newProjectile.GetComponent<Rigidbody2D>();

        if (projectileRb != null)
        {
            projectileRb.AddForce(_gunTip.right * shootingForce, ForceMode2D.Impulse);
        }

        }
    }

 
}
