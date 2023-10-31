using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCamera : MonoBehaviour
{

    private Vector3 cameraTarget;
    private Transform target;

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
        cameraTarget = new Vector3(target.position.x, transform.position.y, target.position.z);
        transform.position = Vector3.Lerp(transform.position, cameraTarget, Time.deltaTime * 8);

    }
}
