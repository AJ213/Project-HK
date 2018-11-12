using UnityEngine;

public interface IShoot
{
    float BulletSpeed { get; set; }
    bool CanShoot { get; set; }
    float ReloadTime { get; set; }
    bool TrackingPlayer { get; set; }
}

public class EnemyShooting : MonoBehaviour
{
    public float bulletSpeed;
    public float bulletsPerShot;
    public bool canShoot;
    public float fireSpread;
    public float playerProximity;
    public float reloadTime;
    public bool spreadRandomized;
    public Transform target;
    private Transform bulletParent;
    private float cooldown = 0.0f;
    private GameObject player;
    public static float DistanceBetween(Vector3 pos1, Vector3 pos2)
    {
        return Mathf.Sqrt(Mathf.Pow(pos1.x - pos2.x, 2) + Mathf.Pow(pos1.y - pos2.y, 2) + Mathf.Pow(pos1.z - pos2.z, 2));
    }

    private void Start()
    {
        bulletParent = GameObject.Find("Bullets").transform;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        cooldown -= Time.deltaTime;
        this.gameObject.transform.eulerAngles = new Vector3(this.gameObject.transform.eulerAngles.x, (target != null) ? Mathf.Rad2Deg * -Mathf.Atan2(target.position.z - this.gameObject.transform.position.z, target.position.x - this.gameObject.transform.position.x) : this.gameObject.transform.eulerAngles.y, this.gameObject.transform.eulerAngles.z);
        if (canShoot)
        {
            if (DistanceBetween(this.gameObject.transform.position, player.transform.position) <= playerProximity && cooldown <= 0.0f)
            {
                for (int i = 0; i < bulletsPerShot; i++)
                {
                    GameObject bullet = (GameObject)Instantiate(Resources.Load("Prefabs/Enemy Bullet"), bulletParent, true);
                    bullet.transform.position = this.gameObject.transform.position;
                    if (bulletsPerShot > 1 && spreadRandomized == false)
                    {
                        bullet.GetComponent<Bullet>().directionDegrees = -this.transform.eulerAngles.y + (i * (fireSpread / (bulletsPerShot - 1))) - (fireSpread / 2.0f);
                    }
                    else
                    {
                        bullet.GetComponent<Bullet>().directionDegrees = -this.transform.eulerAngles.y + Random.Range(-0.5f * fireSpread, 0.5f * fireSpread);
                    }
                    bullet.GetComponent<Bullet>().speed = bulletSpeed;
                }
                cooldown = reloadTime;
            }
        }
    }
}

public class Shoot : IShoot
{
    private float bulletSpeed;
    private bool canShoot;
    private float reloadTime;
    private bool trackingPlayer;
    public float BulletSpeed { get; set; }
    public bool CanShoot { get; set; }
    public float ReloadTime { get; set; }
    public bool TrackingPlayer { get; set; }

    public Shoot(bool canShoot, bool trackingPlayer, float reloadTime, float bulletSpeed)
    {
        this.canShoot = canShoot;
        this.trackingPlayer = trackingPlayer;
        this.reloadTime = reloadTime;
        this.bulletSpeed = bulletSpeed;
    }
}