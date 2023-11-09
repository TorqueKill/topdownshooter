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
        }
        else if (passiveLayer == (passiveLayer | (1 << other.gameObject.layer)))
        {
            Boom();
        }
    }


    //on update, if blast is active, count down to destroy

    void Update()
    {
        if (transform.GetChild(0).gameObject.activeSelf)
        {
            if (blastDelta < blastDuration)
            {
                blastDelta += Time.deltaTime;
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }

    void Boom()
    {
        //activate blast
        transform.GetChild(0).gameObject.SetActive(true);
        //set velocity to 0
        GetComponent<Rigidbody>().velocity = Vector3.zero;
    }
}
