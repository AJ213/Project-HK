using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinHandler : MonoBehaviour
{
    private GameObject[] enemies;
    private float totalStartingEnemies;
    public float enemiesLeft;
    public GameObject shield;

    private void Start()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        totalStartingEnemies = enemies.Length;
        enemiesLeft = totalStartingEnemies;
    }

    private void OnEnable()
    {
        HealthScript.OnDeath += WeakenShield;
    }

    private void OnDisable()
    {
        HealthScript.OnDeath -= WeakenShield;
    }

    private void OnDestroy()
    {
        HealthScript.OnDeath -= WeakenShield;
    }

    void WeakenShield(GameObject killIt)
    {
        if (killIt.tag == "Enemy")
        {
            enemiesLeft--;
            if (enemiesLeft <= 2)
            {
                Destroy(shield);
            }
            if (enemiesLeft <= 1)
            {
                Debug.Log("You Win");
            }
        }
    }

}
