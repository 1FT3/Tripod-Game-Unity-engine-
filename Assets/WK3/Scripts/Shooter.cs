using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shooter : MonoBehaviour
{
    public GameObject PowerCellCount;
    public GameObject powercell; //link to the powerCell prefab
    public GameObject snowCount;
    public GameObject snowball;
    public static int no_cell = 0; //number of powerCell owned
    public static int no_snow = 50; //number of powerCell owned
    public AudioClip throwSound; //throw sound
    public float throwSpeed = 20;//throw speed

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //if left control (fire1) pressed, and we still have at least 1 cell
        if (Input.GetButtonDown("Fire1") && no_cell > 0)
        {
            no_cell--; //reduce the cell
                       
            PowerCellCount.GetComponent<Text>().text = "" + no_cell;
            //play throw sound
            AudioSource.PlayClipAtPoint(throwSound, transform.position);
            //instantaite the power cel as game object
            GameObject cell = Instantiate(powercell, transform.position, transform.rotation) as GameObject;
            //ask physics engine to ignore collison between
            //power cell and our FPSControler
            Physics.IgnoreCollision(transform.root.GetComponent<Collider>(), cell.GetComponent<Collider>(), true);
            //give the powerCell a velocity so that it moves forward
            cell.GetComponent<Rigidbody>().velocity = transform.forward * throwSpeed;
 
        }
        if (Input.GetButtonDown("Fire2") && no_snow > 0)
        {
            no_snow--; //reduce the cell

            snowCount.GetComponent<Text>().text = "" + no_snow;
            //play throw sound
            AudioSource.PlayClipAtPoint(throwSound, transform.position);
            //instantaite the power cel as game object
            GameObject snow = Instantiate(snowball, transform.position, transform.rotation) as GameObject;
            //ask physics engine to ignore collison between
            //power cell and our FPSControler
            Physics.IgnoreCollision(transform.root.GetComponent<Collider>(), snow.GetComponent<Collider>(), true);
            //give the powerCell a velocity so that it moves forward
            snow.GetComponent<Rigidbody>().velocity = transform.forward * throwSpeed;

        }
    }
}
