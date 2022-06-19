using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snowman : MonoBehaviour
{

    public Transform player;
    public float howclose;
    private float dist;
    public float movementSpeed;
    
    [SerializeField] private AudioClip scream;
    private AudioSource snowmanAudioSource;

    [SerializeField] private float damage;
    [SerializeField] private Health _health = null;


  



    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        snowmanAudioSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        dist = Vector3.Distance(player.position, transform.position);
        
          if (dist <= howclose)
        {
            transform.LookAt(player);
            GetComponent<Rigidbody>().AddForce(transform.forward * movementSpeed);
        
         if(!snowmanAudioSource.isPlaying)
          {
            snowmanAudioSource.PlayOneShot(scream);
          }
        }

    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player"){
            _health.currentPlayerHealth -= damage;
            _health.TakeDamage();
            Destroy(gameObject);//destroy self
        }
    }
}
