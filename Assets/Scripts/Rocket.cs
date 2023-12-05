using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    //life
    public float life = 3f;
    public float blastDuration = 0.5f;


    public LayerMask shootableLayer;
    public LayerMask passiveLayer;

    private float blastDelta;

    private ParticleSystem blast;

    public AudioSource boomSound;

    private GameObject player;

    public float audioRange = 50f;

    private bool exploded = false;



    void Start()
    {
        //first get child gameObject called 'explosion'
        blast = transform.GetChild(0).gameObject.GetComponent<ParticleSystem>();

        //set blast to inactive
        blast.gameObject.SetActive(false);

        player = GameObject.Find("Player");
    }

    void Awake()
    {
        Destroy(gameObject, life);
    }

    //when colliding with shootable layer activate 'Blast' child object

    void OnTriggerEnter(Collider other)
    {
        
        if (shootableLayer == (shootableLayer | (1 << other.gameObject.layer)))
        {
            Boom();
            blast.gameObject.SetActive(true);
            blast.Play();
            PlayBoomSound();
        }
        else if (passiveLayer == (passiveLayer | (1 << other.gameObject.layer)))
        {
            Boom();
            blast.gameObject.SetActive(true);
            blast.Play();
            PlayBoomSound();
        }
    }


    //on update, if blast is active, count down to destroy

    void Update()
    {
        if (exploded)
        {
            return;
        }


        if (transform.GetChild(1).gameObject.activeSelf)
        {
            if (blastDelta < blastDuration)
            {
                blastDelta += Time.deltaTime;
            }
            else
            {
                //set hitbox to inactive
                transform.GetChild(1).gameObject.SetActive(false);
                exploded = true;
            }
        }
    }

    void Boom()
    {

        //activate blast
        transform.GetChild(1).gameObject.SetActive(true);
        //set velocity to 0
        GetComponent<Rigidbody>().velocity = Vector3.zero;

        //set self mesh to inactive
        GetComponent<MeshRenderer>().enabled = false;
    }

    void PlayBoomSound()
    {
        if (boomSound != null)
        {
            //check if player exists
            if (player != null)
            {
                //check if player is within range
                if (Vector3.Distance(transform.position, player.transform.position) < audioRange)
                {
                    //play sound
                    boomSound.Play();
                }
            }
            else
            {
                //play sound
                boomSound.Play();
            }
        }
    }
}
