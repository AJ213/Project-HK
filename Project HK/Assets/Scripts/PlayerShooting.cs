using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    Transform bulletParent;
    public float reloadTime = 0.2f;
    float cooldown = 0.0f;

	void Start ()
    {
        bulletParent = GameObject.Find("Bullets").transform;
	}
	
	void Update ()
    {
        cooldown -= Time.deltaTime;
		if (Input.GetButton("Fire1") && cooldown <= 0.0f)
        {
            GameObject bullet = (GameObject) Instantiate(Resources.Load("Prefabs/Player Bullet"), bulletParent, true);
            bullet.transform.position = this.gameObject.transform.position;
            bullet.GetComponent<Bullet>().directionDegrees = -this.gameObject.transform.eulerAngles.y;
            bullet.GetComponent<Bullet>().speed = 10.0f;
            cooldown = reloadTime;
            GetComponent<AudioSource>().Play();
        }
        
	}
}
