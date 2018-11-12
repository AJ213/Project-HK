using UnityEngine;

public class HealthScript : MonoBehaviour
{
    private AudioSource deathSound;
    [SerializeField] private float health;
    private AudioSource hitSound;
    [SerializeField] private bool isDestructable;

    public float Health
    {
        get { return health; }
        set
        {
            if (isDestructable)
            {
                health = value;
                if (GameObject.FindGameObjectWithTag("Player") != this)
                {
                    hitSound.Play();
                }
                if (health <= 0)
                {
                    deathSound.Play();
                    OnDeath(this.gameObject);
                }
            }
        }
    }

    public delegate void Die(GameObject killIt);

    public static event Die OnDeath;
    private void Awake()
    {
        AudioSource[] audios = GameObject.FindGameObjectWithTag("Player").GetComponents<AudioSource>();
        hitSound = audios[1];
        deathSound = audios[2];
    }
}