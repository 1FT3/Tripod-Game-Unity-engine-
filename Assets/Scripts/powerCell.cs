using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerCell : MonoBehaviour
{
    public GameObject explode;
    private GameObject tripod;
    float removeTime = 3.0f;
    // Use this for initialization
    void Start () {
        tripod = GameObject.Find ("tripod");//find the tripod
        Destroy(gameObject, removeTime); //destory the object after 2s
    }


    void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag == "Enemy") {
        //reduce the tripod's health
        tripod.GetComponent<tripodHealth>().reduceHealth();
        Destroy(gameObject);//destory self
    }
    else if(other.gameObject.tag  == "Box"){
            // Instantiate(explode, transform.position, transform.rotation);
            Destroy(other.gameObject);
            Destroy(gameObject);//destory self
    }
  
}

    void OnDestroy(){
    
        Instantiate(explode, transform.position, transform.rotation);
        //Destroy(gameObject);//destory self
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
