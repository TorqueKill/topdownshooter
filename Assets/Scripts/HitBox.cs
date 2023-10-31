using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox : MonoBehaviour
{
    public float damagePerSecond = 10f; // Damage per frame
    public float knockbackPerSecond = 10f; // Knockback per frame

    public LayerMask layerMask;

    private float damagePerFrame ; // Variable to store damage per second
    private float knockbackPerFrame ; // Variable to store knockback per second

    private void Start()
    {
        damagePerFrame = damagePerSecond * Time.deltaTime;
        knockbackPerFrame = knockbackPerSecond * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (layerMask == (layerMask | (1 << other.gameObject.layer)))
        {
            EntityHurtBox hurtBox = other.GetComponent<EntityHurtBox>();

            if (hurtBox != null)
            {
                hurtBox.entityHealth.health -= damagePerFrame;
                //hurtBox.entityRigidbody.AddForce(transform.forward * knockbackPerFrame, ForceMode.Impulse);
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (layerMask == (layerMask | (1 << other.gameObject.layer)))
        {
            EntityHurtBox hurtBox = other.GetComponent<EntityHurtBox>();

            if (hurtBox != null)
            {
                hurtBox.entityHealth.health -= damagePerFrame;
                //hurtBox.entityRigidbody.AddForce(transform.forward * knockbackPerFrame, ForceMode.Impulse);
            }
        }
    }
}
