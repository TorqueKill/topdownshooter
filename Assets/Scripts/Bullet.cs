using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float life = 3;

    //public variable to indicate shootables
    public LayerMask shootableLayer;
    public LayerMask passiveLayer;


    void Awake()
    {
        Destroy(gameObject, life);
    }
    void OnTriggerEnter(Collider other)
    {
        // Destroy the bullet and the object it collided with
        //check if the object is an enemy
        // if (collision.gameObject.tag == "ENEMY")
        // {
        //     //if it is, destroy it
        //     Destroy(collision.gameObject);
        // }

        //only destroy if the object is an enemy layer

        if (shootableLayer == (shootableLayer | (1 << other.gameObject.layer))){

           EntityHurtBox hurtBox = other.GetComponent<EntityHurtBox>();

           if (hurtBox != null){

                hurtBox.entityHealth.health -= 10;
           }

            Destroy(gameObject);
        }else if (passiveLayer == (passiveLayer | (1 << other.gameObject.layer))){

            Destroy(gameObject);
        }
        //Destroy(collision.gameObject);
        //Destroy(gameObject);
    }
}
