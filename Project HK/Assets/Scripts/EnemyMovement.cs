using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float playerProximity;
    public Transform[] newPos1;
    public Vector3[] newPos2;
    Vector3 newPos;
    public float[] speed;
    public float[] destinationProximity;

    int currentStep;

    GameObject player;
    private void Start()
    {
        currentStep = 0;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void FixedUpdate()
    {
        if (DistanceBetween(this.gameObject.transform.position, player.transform.position) <= playerProximity)
        {
            //newPos = (newPos1[currentStep] != null) ? newPos1[currentStep].position : newPos2[currentStep];
            if (newPos1[currentStep] != null)
            {
                newPos = newPos1[currentStep].position;
            }
            else
            {
                newPos = newPos2[currentStep];
            }
            float direction = Mathf.Atan2(-this.gameObject.transform.position.z + newPos.z, -this.gameObject.transform.position.x + newPos.x);
            this.gameObject.transform.position += new Vector3(speed[currentStep] * Mathf.Cos(direction), 0, speed[currentStep] * Mathf.Sin(direction));
            if (DistanceBetween(this.transform.position, newPos) < destinationProximity[currentStep])
            {
                currentStep += 1;
                currentStep %= speed.Length;
            }
        }
    }


    float DistanceBetween(Vector3 pos1, Vector3 pos2)
    {
        return Mathf.Sqrt(Mathf.Pow(pos1.x - pos2.x, 2) + Mathf.Pow(pos1.y - pos2.y, 2) + Mathf.Pow(pos1.z - pos2.z, 2));
    }
}
