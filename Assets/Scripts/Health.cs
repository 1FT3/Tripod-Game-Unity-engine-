using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public float currentPlayerHealth;
    public float maxPlayerHealth = 100.0f;
    
    public GameObject GameOver;

    [SerializeField] private Image DamageUI = null;


    private float hurtTimer = 0.5f;
    [SerializeField] private Image DamageUI2 = null;


  
    [SerializeField] private AudioClip DamagedAudio = null;
    private AudioSource healthAudioSource;

    private void Start()
    {
        healthAudioSource = GetComponent<AudioSource>();
    }

    //Updates health accordingly with the picture of the damage
    public void UpdateHealth()
    {
        //Local variable to change the alpha value of the splatter image
        Color splatterAlpha = DamageUI.color;
        //Alpha component
        splatterAlpha.a = 1 - (currentPlayerHealth / maxPlayerHealth);
        DamageUI.color = splatterAlpha;
    }
    //Show the hurt flashing image for a very small second along with sound and only 
    public IEnumerator HurtFlash()
    {
        DamageUI2.enabled = true;
        healthAudioSource.PlayOneShot(DamagedAudio);
        yield return new WaitForSeconds(hurtTimer);
        DamageUI2.enabled = false;
    }
     
     // When taking damage the flashing image will appear and update health accordingly
   
    public void TakeDamage()
    {
        if (currentPlayerHealth >= 0)
        {   
            StartCoroutine(HurtFlash());
            UpdateHealth();        
        }
    }

    public void Update()
    {  
        if (currentPlayerHealth <= 0)
        {
            GameOver.SetActive(true);
        }
    }

}
