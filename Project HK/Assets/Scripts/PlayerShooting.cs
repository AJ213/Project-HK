using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public float reloadTime = 0.2f;
    private Transform bulletParent;
    private float cooldown = 0.0f;

    private void Start()
    {
        bulletParent = GameObject.Find("Bullets").transform;
    }

    private void Update()
    {
        cooldown -= Time.deltaTime;
        if (Input.GetButton("Fire1") && cooldown <= 0.0f)
        {
            GameObject bullet = (GameObject)Instantiate(Resources.Load("Prefabs/Player Bullet"), bulletParent, true);
            bullet.transform.position = this.gameObject.transform.position;
            bullet.GetComponent<Bullet>().directionDegrees = -this.gameObject.transform.eulerAngles.y;
            bullet.GetComponent<Bullet>().speed = 10.0f;
            cooldown = reloadTime;
            GetComponent<AudioSource>().Play();
        }
    }
}