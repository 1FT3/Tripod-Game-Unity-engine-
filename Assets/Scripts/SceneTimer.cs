using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneTimer : MonoBehaviour
{
 
[SerializeField] private float timer = 65f; 
private float timePassed;

    // Once time passed is greater then given timer then load new scene
    void Update()
    {
        timePassed += Time.deltaTime;

       if (timePassed > timer)
       {
         SceneManager.LoadScene("Main Menu");
       } 
    }
}
