using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public float directionDegrees;
    float directionRadians;
    public float despawnDistance;

    private void Start()
    {
        directionRadians = Mathf.Deg2Rad * directionDegrees;
        this.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(speed * Mathf.Cos(directionRadians), 0, speed * Mathf.Sin(directionRadians));
        this.gameObject.transform.eulerAngles = new Vector3 (this.gameObject.transform.eulerAngles.x, -directionDegrees, this.gameObject.transform.eulerAngles.z);
    }

    private void Update()
    {
        if(EnemyShooting.DistanceBetween(this.gameObject.transform.position, GameObject.FindGameObjectWithTag("Player").transform.position) > despawnDistance)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if ((collision.gameObject.tag == "Enemy" && this.gameObject.tag == "Player Bullets") || (collision.gameObject.tag == "Player" && this.gameObject.tag == "Enemy Bullets"))
        {
            //Debug.Log("Bullet from (" + this.gameObject.tag +") Hit a entity from (" + collision.gameObject.tag + ")");
            collision.gameObject.GetComponent<HealthScript>().Health -= 1;
        }
        Destroy(this.gameObject);
    }
}
