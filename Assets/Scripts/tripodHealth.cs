using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class tripodHealth : MonoBehaviour
{
    public GameObject GameComplete;
    public Slider healthSlider;
    public GameObject explode;
   [SerializeField] private float health;
    public GameObject smoke, flare;
    public void reduceHealth()
    {
        health--;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

   
    void Update()
    {
        
        healthSlider.value = GetComponent<tripodHealth>().DisplayHP() / 3.0f;
        if (health == 1 )
        {
            smoke.SetActive(true);
            flare.SetActive(true);
        }

        else if (health <= 0)
        {
       
        Destroy(gameObject);//destory self
        SceneManager.LoadScene("EndCredits");

        }
    }


  //Displays the HP of the tripod.
    public float DisplayHP()
    {
        return health;
    }

}
