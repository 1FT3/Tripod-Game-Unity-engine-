using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAi : MonoBehaviour
{
    public Transform player;
    public GameObject laser;
    public float howclose;
    private float dist;
    private float dist2;
    public float movementSpeed;
    public Transform[] move;

    private int index;
 
    [SerializeField] private float timeBtwShots;
  

    LineRenderer linerend;
    
    [SerializeField] private float damage;
    [SerializeField] private Health _health = null;

    [SerializeField] private AudioClip LaserAudio = null;
    private AudioSource EnemyAiAudioSource;


    Rigidbody rb;
    Animator animator;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        index = 0;
        transform.LookAt(move[index].position);
        animator = GetComponent<Animator>();
        EnemyAiAudioSource = GetComponent<AudioSource>();
        linerend  =  laser.GetComponent<LineRenderer>();

    }


    // Update is called once per frame
    void Update()
    {
        //Animator 
        animator.SetBool("Walking", true);
        //gets the distance of the player and tripod 
        dist = Vector3.Distance(player.position, transform.position);

        //gets the distance of the tripod and the next it needs to move to.
        dist2 = Vector3.Distance(transform.position, move[index].position);


        //checks if the tripod is close enough to the player to then follow it.
        if (dist <= howclose)
        {
            transform.LookAt(player);
            GetComponent<Rigidbody>().AddForce(transform.forward * movementSpeed);
        }

        // checks if the tripod is close to any point it can move to.
        else if (dist2 < 9f) {
            Patrol();
        }
        forward();

        //check if the tripod is close enough to the player to then attack it.
        if (dist <= 10.5f && timeBtwShots <= 0)
        {

            laser.SetActive(true);
            linerend.SetPosition(0, laser.transform.position);
            linerend.SetPosition(1, player.transform.position);
            _health.currentPlayerHealth -= damage;
            _health.TakeDamage();

            if(!EnemyAiAudioSource.isPlaying)
          {
            EnemyAiAudioSource.PlayOneShot(LaserAudio);
          }

        }

        else
        {
           laser.SetActive(false);
            
            timeBtwShots -= Time.deltaTime;
        }


    }

    //moves the tripode forward at the speed inputted. 
    void forward()
    {
        transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime); 

    }

    // Loops through update.
    // checks if the index has reached the maximum length of array to reset and allow the tripod to continue patrolling.
    void Patrol()
    {
        index++;
        if(index >= move.Length)
        {
            index = 0;
        }

        transform.LookAt(move[index].position);
    }


    


}