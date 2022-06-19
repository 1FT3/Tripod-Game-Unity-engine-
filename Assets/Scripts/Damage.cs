using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    
    [SerializeField] private float damage;
    [SerializeField] private GameObject explosionParticle = null;
    [SerializeField] private Health _health = null;

  
    [SerializeField] private AudioClip bombAudio = null;
    private bool playingAudio;
    private AudioSource bombAudioSource;

    private void Start()
    {
        bombAudioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            explosionParticle.SetActive(true);
            bombAudioSource.PlayOneShot(bombAudio);
            _health.currentPlayerHealth -= damage;
            _health.TakeDamage();
            playingAudio = true;
        }
    }

    private void Update()
    {
        if (playingAudio)
        {
            if (!bombAudioSource.isPlaying)
            {
                gameObject.SetActive(false);
            }
        }
    }
}
