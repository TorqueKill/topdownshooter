using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script is attached to the enemy prefab, enemy1 will only chase the player
public class Enemy1 : MonoBehaviour
{
    private Vector3 enemyTarget;
    private Transform target;

    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        // Calculate the direction to the player
        Vector3 direction = target.position - transform.position;

        // Normalize the direction vector
        direction.Normalize();

        // Calculate the target position for the enemy to move towards
        enemyTarget = transform.position + direction;

        // Move the enemy towards the target position
        transform.position = Vector3.Lerp(transform.position, enemyTarget, speed * Time.deltaTime);
    }
}