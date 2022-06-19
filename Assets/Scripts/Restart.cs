using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Restart : MonoBehaviour
{
    public void restart()
    {
       SceneManager.LoadScene("level01");
       
    }

    public void Quit()
    {
       SceneManager.LoadScene("Main Menu"); 
    }

}
