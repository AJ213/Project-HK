using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    private void KillEnemy(GameObject killIt)
    {
        if (killIt == this.gameObject)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnDestroy()
    {
        HealthScript.OnDeath -= KillEnemy;
    }
    private void OnDisable()
    {
        HealthScript.OnDeath -= KillEnemy;
    }
    private void OnEnable()
    {
        HealthScript.OnDeath += KillEnemy;
    }
}