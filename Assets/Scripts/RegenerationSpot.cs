using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegenerationSpot : MonoBehaviour
{
    [SerializeField] private FirstPersonAIO  _stamina = null;
    [SerializeField] private int RegenerationRate = 1;


    [SerializeField] private AudioClip StaminaAudio = null;
    private AudioSource RegenerationSpotAudioSource;

    private bool canRegenerate = false;


    void Start()
    {
        RegenerationSpotAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
    //Conditions for stamina to regenerate 
      if (canRegenerate)
        {
        if(_stamina.staminaInternal<_stamina.staminaLevel){
                _stamina.staminaInternal += Time.deltaTime * RegenerationRate;
    }
     else
            {
                _stamina.staminaInternal = _stamina.staminaLevel;
              
                canRegenerate = false;
            }
    
    }
    }


   private void OnTriggerEnter(Collider other)
    {
              //If stamina less than maximum upon coming in contact with the Aura then allow regeneration and play audio effect

       if (_stamina.staminaInternal<_stamina.staminaLevel)
        {
            canRegenerate = true;
            RegenerationSpotAudioSource.PlayOneShot(StaminaAudio);
        }
   }
    
    //If exiting the aura then stop regeneration
    private void OnTriggerExit(Collider other)
    {

        if (_stamina.staminaInternal < _stamina.staminaLevel)
        {
            canRegenerate = false;
        }
    }
}
