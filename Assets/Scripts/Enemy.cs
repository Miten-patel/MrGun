using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] private GameObject _bulletPrefab;
    public Transform _gunTip;
    [SerializeField] private float shootingForce = 10f;
    [SerializeField] private GameObject _enemy;
    [SerializeField] private bool BulletShooted;
    [SerializeField] private Transform _gun;
    public float _health = 1;





    public static Enemy Inst;


    private void Awake()
    {
        Inst = this;
    }
    // Update is called once per frame
    void Update()
    {
        EnemyMove();
        Health();
    }


    public void EnemyMove()
    {  
        transform.position = Vector3.MoveTowards(transform.position, StairsManager.inst.platformData.endPoint.position, Time.deltaTime * 3);
    }

    public void Health()
    {
        if (_health <= 0)
        {
            Destroy(gameObject);
        }
    }


    private void OnEnable()
    {
        Events.BulletMiss += PointGunAtPlayer;
    }

    private void OnDisable()
    {
        Events.BulletMiss -= PointGunAtPlayer;
    }

    public  void PointGunAtPlayer()
    {
        Debug.Log("Aim");
        Vector3 playerPos = Player.inst.transform.position;
        Vector3 direction = playerPos - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.Euler(0f, 0f, angle);

        _gun.rotation = rotation;

        Shoot();

    }



    public void Shoot()
    {
        if (!BulletShooted)
        {

            GameObject newProjectile = Instantiate(_bulletPrefab, _gunTip.position, _gunTip.rotation);
            BulletShooted = true;

            Rigidbody2D projectileRb = newProjectile.GetComponent<Rigidbody2D>();

            if (projectileRb != null && transform.localScale.x > 0f)
            {
                Debug.Log("positive Force");
                projectileRb.AddForce(_gunTip.right * shootingForce, ForceMode2D.Impulse);
                BulletShooted = true;
            }

            else
            {
                Debug.Log("negative Force");
                projectileRb.AddForce(_gunTip.right * -shootingForce, ForceMode2D.Impulse);
                BulletShooted = true;

            }
        }

    }


    


}
