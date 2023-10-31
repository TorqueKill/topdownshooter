using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityHurtBox : MonoBehaviour
{
    public EntityHealth entityHealth;
    public Rigidbody entityRigidbody;


    private void Start(){ 

        entityHealth = transform.GetComponent<EntityHealth>();
        entityRigidbody = transform.GetComponent<Rigidbody>();
    
    }
        
}
