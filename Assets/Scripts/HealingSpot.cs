using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealingSpot : MonoBehaviour
{


    [SerializeField] private Health _health = null;
    [SerializeField] private int RegenerationRate = 1;
 

    [SerializeField] private AudioClip HealingAudio = null;
    private AudioSource HealingSpotAudioSource;

    private bool canRegenerate = false;


     private void Start()
    {
        HealingSpotAudioSource = GetComponent<AudioSource>();
    }


    private void Update()
    {
          //Conditions for healths to regenerate at the rate specified above
         if (canRegenerate)
        {
            //Only regenerate health if less than max and update the remove the damaged image
            if (_health.currentPlayerHealth <= _health.maxPlayerHealth)
            {
                 _health.currentPlayerHealth += Time.deltaTime * RegenerationRate;
                _health.UpdateHealth();
                 
                
            }
            else
            {
                //No regeneration if already at maximum palyer health
                 _health.currentPlayerHealth = _health.maxPlayerHealth;             
                canRegenerate = false;
            }
        }
        
    }

    

    private void OnTriggerEnter(Collider other)
    {
       //If health less than maximum upon coming in contact with the Aura then allow regeneration and play audio effect
       if (_health.currentPlayerHealth <= 99)
        {
            canRegenerate = true;
            _health.UpdateHealth();
            HealingSpotAudioSource.PlayOneShot(HealingAudio);      

        }
   }

    //If exiting the aura then stop regeneration
    private void OnTriggerExit(Collider other)
    {

        if (_health.currentPlayerHealth <= 99)
        {
            canRegenerate = false;
            _health.UpdateHealth();

        }
    }

} 

 


