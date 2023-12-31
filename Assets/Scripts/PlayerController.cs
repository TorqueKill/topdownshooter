using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// get character controller component

[RequireComponent(typeof(CharacterController))]


public class PlayerController : MonoBehaviour
{

    // create variables
    public float speed = 5;
    public float turnSpeed = 10;
    public float runSpeed = 10;
    


    private Quaternion _targetRotation;
    private CharacterController _controller;

    // Start is called before the first frame update
    void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
            
            // get input from the player
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");
            
            

    
            // move the player
            Vector3 direction = new Vector3(horizontalInput, 0, verticalInput);
            //run or walk based on shift key
            if (Input.GetKey(KeyCode.LeftShift))
            {
                _controller.Move(direction * runSpeed * Time.deltaTime);
            }
            else
            {
                _controller.Move(direction * speed * Time.deltaTime);
            }
    
            // rotate the player
            if (direction.magnitude > 0)
            {
                _targetRotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Lerp(transform.rotation, _targetRotation, Time.deltaTime * turnSpeed);
            }
            
        
    }
}
