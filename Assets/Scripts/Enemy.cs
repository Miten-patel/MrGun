using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _gunTip;
    [SerializeField] private float shootingForce = 10f;
    [SerializeField] private GameObject _enemy;


    // Update is called once per frame
    void Update()
    {
        EnemyMove();

    }


    public void EnemyMove()
    {  
        transform.position = Vector3.MoveTowards(transform.position, Player.inst.platformData.endPoint.position, Time.deltaTime * 3);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        StateManager.instance.PlayerStates = Player.inst.Movements;
    }

    private void PointGunAtPlayer()
    {
        Vector3 playerPos = Player.inst.transform.position;
        Vector3 direction = playerPos - transform.position;


    }



    public void Shoot()
    {

   
            GameObject newProjectile = Instantiate(_bulletPrefab, _gunTip.position, _gunTip.rotation);
            Rigidbody2D projectileRb = newProjectile.GetComponent<Rigidbody2D>();

            if (projectileRb != null && _enemy.transform.localScale.x > 0f)
            {

                projectileRb.AddForce(_gunTip.right * shootingForce, ForceMode2D.Impulse);

            }

            else
            {
                projectileRb.AddForce(_gunTip.right * -shootingForce, ForceMode2D.Impulse);

            }

    }


}
