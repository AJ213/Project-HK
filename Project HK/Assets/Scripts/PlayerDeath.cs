using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    private void KillPlayer(GameObject killIt)
    {
        if (killIt == this.gameObject)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
            //GameObject.FindGameObjectWithTag("GameController").GetComponent<LevelHandler>().Restart();
            //Destroy(this.gameObject);
        }
    }
    private void OnDestroy()
    {
        HealthScript.OnDeath -= KillPlayer;
    }
    private void OnDisable()
    {
        HealthScript.OnDeath -= KillPlayer;
    }
    private void OnEnable()
    {
        HealthScript.OnDeath += KillPlayer;
    }
}