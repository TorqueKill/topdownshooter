using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Marker : MonoBehaviour
{

    private Transform _target;

    void Start()
    {
        findNextObjective();
    }

    // Update is called once per frame
    void Update()
    {
        if (_target == null)
        {
            findNextObjective();
        }
        else
        {
            
            transform.LookAt(_target);
        }
        
    }

    void findNextObjective()
    {
        //find the closest objective
        float closestDistance = Mathf.Infinity;
        GameObject closestObjective = null;

        var objectives = GameObject.FindGameObjectsWithTag("Objective");

        if (objectives.Length == 0)
        {
            return;
        }

        foreach (GameObject objective in objectives)
        {
            float distance = Vector3.Distance(transform.position, objective.transform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestObjective = objective;
            }
        }

        _target = closestObjective.transform;
    }
}
