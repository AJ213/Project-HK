using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public float playerProximity;
    public bool canShoot;
    public Transform target;
    public float reloadTime;
    public float bulletSpeed;
    public float fireSpread;
    public float bulletsPerShot;
    public bool spreadRandomized;

    GameObject player;
    Transform bulletParent;
    float cooldown = 0.0f;

    void Start()
    {
        bulletParent = GameObject.Find("Bullets").transform;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
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
                        bullet.GetComponent<Bullet>().directionDegrees = -this.transform.eulerAngles.y + i * (fireSpread / (bulletsPerShot - 1)) - (fireSpread / 2.0f);
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

    public static float DistanceBetween(Vector3 pos1, Vector3 pos2)
    {
        return Mathf.Sqrt(Mathf.Pow(pos1.x - pos2.x, 2) + Mathf.Pow(pos1.y - pos2.y, 2) + Mathf.Pow(pos1.z - pos2.z, 2));
    }
    
}

public interface IShoot
{
    float ReloadTime { get; set; }
    float BulletSpeed { get; set; }
    bool CanShoot { get; set; }
    bool TrackingPlayer { get; set; }
}

public class Shoot : IShoot
{
    float reloadTime; public float ReloadTime { get { return reloadTime; } set { reloadTime = value; } }
    float bulletSpeed; public float BulletSpeed { get { return bulletSpeed; } set { bulletSpeed = value; } }
    bool canShoot; public bool CanShoot { get { return canShoot; } set { canShoot = value; } }
    bool trackingPlayer; public bool TrackingPlayer { get { return trackingPlayer; } set { trackingPlayer = value; } } 

    public Shoot(bool CanShoot, bool TrackingPlayer, float ReloadTime, float BulletSpeed)
    {
        canShoot = CanShoot;
        trackingPlayer = TrackingPlayer;
        reloadTime = ReloadTime;
        bulletSpeed = BulletSpeed;
    }

}
