using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    private Transform target;
    public LayerMask collisionLayer;
    public float speed;

    public float aggroRange = 25f; //distance at which enemy will start following player

    public float attackRange = 5f; //distance at which enemy will attack player

    public bool isFollowing = false;

    public bool isAttacking = false;


    // Start is called before the first frame update
    void Start()
    {
        //target = GameObject.Find("Player").transform;

        //check if player is deleted
        if (GameObject.Find("Player") != null)
        {
            target = GameObject.Find("Player").transform;
        }
        else
        {
            //stop update
            return;
        }
    }

    // Update is called once per frame
    void Update()
    {

        //check if player is deleted
        if (target == null)
        {   
            isAttacking = false;
            isFollowing = false;

            //stop update
            return;
        }

        //return if player is too far away
        if (Vector3.Distance(transform.position, target.position) > aggroRange)
        {
            isFollowing = false;
            return;
        }

        isFollowing = true;

        //check if player is close enough to attack
        if (Vector3.Distance(transform.position, target.position) < attackRange)
        {
            isAttacking = true;
        }
        else
        {
            isAttacking = false;
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
            //also face the player
            transform.LookAt(target);
        }
    }
}
