using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    private void OnEnable()
    {
        HealthScript.OnDeath += KillEnemy;
    }

    private void OnDisable()
    {
        HealthScript.OnDeath -= KillEnemy;
    }

    private void OnDestroy()
    {
        HealthScript.OnDeath -= KillEnemy;
    }

    void KillEnemy(GameObject killIt)
    {
        if (killIt == this.gameObject)
        {
            Destroy(this.gameObject);
        }
    }
}
