using UnityEngine;

public class WinHandler : MonoBehaviour
{
    public float enemiesLeft;
    public GameObject shield;
    private GameObject[] enemies;
    private float totalStartingEnemies;
    private void OnDestroy()
    {
        HealthScript.OnDeath -= WeakenShield;
    }
    private void OnDisable()
    {
        HealthScript.OnDeath -= WeakenShield;
    }
    private void OnEnable()
    {
        HealthScript.OnDeath += WeakenShield;
    }
    private void Start()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        totalStartingEnemies = enemies.Length;
        enemiesLeft = totalStartingEnemies;
    }

    private void WeakenShield(GameObject killIt)
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