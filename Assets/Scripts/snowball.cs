using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snowball : MonoBehaviour
{
    public GameObject explode;
    private GameObject snowman;
    float removeTime = 3.0f;
    // Use this for initialization
    void Start()
    {
        snowman = GameObject.Find("snowman");//find the tripod
        Destroy(gameObject, removeTime); //destroy the object after 2s
    }


    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "snowman")
        {
            //Destroys the snowman.
            Instantiate(explode, transform.position, transform.rotation);
            Destroy(other.gameObject);
            Destroy(gameObject);//destory self
        }
       

    } 
    
    // Update is called once per frame
    void Update()
    {

    }
}
