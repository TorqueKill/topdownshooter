using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    private Transform target;
    public LayerMask collisionLayer;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {

        //check if player is deleted
        if (target == null)
        {
            //stop update
            return;
        }


        // Calculate the direction to the player
        Vector3 direction = target.position - transform.position;

        // Normalize the direction vector
        direction.Normalize();

        // Calculate the target position for the enemy to move towards
        Vector3 enemyTarget = transform.position + direction;

        // Use a raycast to check for collisions in the movement direction
        if (Physics.Raycast(transform.position, direction, out RaycastHit hit, 1f, collisionLayer))
        {
            // Handle collisions, you can add your logic here
        }
        else
        {
            // Move the enemy towards the target position
            transform.position = Vector3.Lerp(transform.position, enemyTarget, speed * Time.deltaTime);
        }
    }
}
