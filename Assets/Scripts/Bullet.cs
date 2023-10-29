using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float life = 3;

    //public variable to indicate shootables
    public string shootableTag = "ENEMY";


    void Awake()
    {
        // Destroy the bullet after a certain amount of time
        Destroy(gameObject, life);
    }
    void OnCollisionEnter(Collision collision)
    {
        // Destroy the bullet and the object it collided with
        //check if the object is an enemy
        if (collision.gameObject.tag == "ENEMY")
        {
            //if it is, destroy it
            Destroy(collision.gameObject);
        }
        Destroy(gameObject);
    }
}
