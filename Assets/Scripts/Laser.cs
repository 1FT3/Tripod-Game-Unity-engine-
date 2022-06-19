using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Laser : MonoBehaviour
{
    public float speed;
    private Transform player;
    private Vector2 target;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = new Vector2(player.position.x, player.position.y); // gets both end points of target 
    }

    void Update()
    {
      transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime); //moved the laser towards the user to deal damage.
    }
   
}
