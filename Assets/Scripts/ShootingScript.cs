//using UnityEngine;

//public class ShootingScript : MonoBehaviour
//{
//    public static ShootingScript instance;

//    [SerializeField] private GameObject _bulletPrefab;
//    [SerializeField] private Transform _gunTip;
//    [SerializeField] private float shootingForce = 10f;
//    [SerializeField] private GameObject _player;
//    public bool bulletShooted;


//    private void Awake()
//    {
//        instance = this;
//    }

//    public void Shoot()
//    {

//        if (Input.GetButtonDown("Fire1") && bulletShooted == false)
//        {

//            GameObject newProjectile = Instantiate(_bulletPrefab, _gunTip.position, _gunTip.rotation);
//            //Rigidbody2D projectileRb = newProjectile.GetComponent<Rigidbody2D>();

//            //if (projectileRb != null && _player.transform.localScale.x > 0f)
//            //{

//            //    projectileRb.AddForce(_gunTip.right * shootingForce, ForceMode2D.Impulse);
//            //    bulletShooted = true;
//            //    Player.inst.PlayerStates = Enemy.Inst.PointGunAtPlayer;

//            //}

//            //else
//            //{
//            //    projectileRb.AddForce(_gunTip.right * -shootingForce, ForceMode2D.Impulse);
//            //    bulletShooted = true;
//            //    Player.inst.PlayerStates = Enemy.Inst.PointGunAtPlayer;


//            //}

//        }
//    }

 
//}
