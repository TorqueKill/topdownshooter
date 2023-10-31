using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox : MonoBehaviour
{
    public float damage = 10f;
    public float knockback = 10f;

    public LayerMask layerMask;

    private void OnTriggerEnter(Collider other)
    {

        if (layerMask == (layerMask | (1 << other.gameObject.layer)))
        {
            EntityHurtBox hurtBox = other.GetComponent<EntityHurtBox>();

            if (hurtBox != null)
            {
                hurtBox.entityHealth.health -= damage;
                //hurtBox.entityRigidbody.AddForce(transform.forward * knockback, ForceMode.Impulse);
            }
        }


    }
}
