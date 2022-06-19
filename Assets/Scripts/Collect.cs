using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collect : MonoBehaviour
{
    public GameObject PowerCellCount;
    private int rotation = 1;
    public AudioClip throwSound;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        PowerCellCount.GetComponent<Text>().text = "" + Shooter.no_cell;
        transform.Rotate(0, rotation, 0, Space.World);
    }

    //adds one cell to user after each trigger.
    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Player")){
            Shooter.no_cell +=1;
            AudioSource.PlayClipAtPoint(throwSound, transform.position);
            
            //deactivate the other object
            gameObject.SetActive (false);
            
        }
        
       
            

        
      
    }
}
