using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
    [SerializeField] bool isDestructable;
    [SerializeField] private float health;

    public float Health
    {
        get { return health; }
        set
        {
            if (isDestructable)
            {
                health = value;
                if(GameObject.FindGameObjectWithTag("Player") != this)
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
    AudioSource hitSound;
    AudioSource deathSound;
    private void Awake()
    {
        AudioSource[] audios = GameObject.FindGameObjectWithTag("Player").GetComponents<AudioSource>();
        hitSound = audios[1];
        deathSound = audios[2];
    }

    public delegate void Die(GameObject killIt);
    public static event Die OnDeath;
}
