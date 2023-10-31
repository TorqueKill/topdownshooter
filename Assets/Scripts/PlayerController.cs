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

    public float rotateSpeed = 10;

    public float dashDistance = 5;

    public bool mouseKeyboardControl = false;

    public float knifeCooldown = 1f;
    public float dashCooldown = 1f;

    public string meleeWeapon = "Knife";


    public KeyCode RotateLeft = KeyCode.Q;
    public KeyCode RotateRight = KeyCode.E;



    private bool _canDash = true;
    private bool _canKnife = true;
    private Quaternion _targetRotation;
    private Vector3 _direction;
    private Vector3 _lookingDirection;
    private CharacterController _controller;
    private Camera cam;


    // Start is called before the first frame update
    void Start()
    {
        _controller = GetComponent<CharacterController>();
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        //check if player is deleted
        if (gameObject == null)
        {
            //stop update
            return;
        }

        //check if mouse and keyboard control is true
        if (mouseKeyboardControl)
        {
            mouseKeyboard();
        }
        else
        {
            lookWithAltKeys();
        }

        //check if player can knife using leftcontrol
        if (Input.GetKeyDown(KeyCode.LeftControl) && _canKnife)
        {
            //activate knife
            knife();

        }

        //check if player can dash using rightclick
        if (Input.GetKeyDown(KeyCode.Mouse1) && _canDash)
        {
            //activate dash
            dash();
        }


    }

    //create a method for WASD
    void WASD()
    {

        // get input from the player
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");




        // move the player
        _direction = new Vector3(horizontalInput, 0, verticalInput);
        //run or walk based on shift key
        if (Input.GetKey(KeyCode.LeftShift))
        {
            _controller.Move(_direction * runSpeed * Time.deltaTime);
        }
        else
        {
            _controller.Move(_direction * speed * Time.deltaTime);
        }

        // rotate the player
        if (_direction.magnitude > 0)
        {
            _targetRotation = Quaternion.LookRotation(_direction);
            transform.rotation = Quaternion.Lerp(transform.rotation, _targetRotation, Time.deltaTime * turnSpeed);
        }
    }



    //create a method for mouse and keyboard
    void mouseKeyboard()
    {
        // get input from the player
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        //get mouse pos
        Vector3 mousePos = Input.mousePosition;
        //get world pos
        Vector3 worldPos = cam.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, cam.transform.position.y - transform.position.y));


        // move the player
        _direction = new Vector3(horizontalInput, 0, verticalInput);

        //run or walk based on shift key
        if (Input.GetKey(KeyCode.LeftShift))
        {
            _controller.Move(_direction * runSpeed * Time.deltaTime);
        }
        else
        {
            _controller.Move(_direction * speed * Time.deltaTime);
        }

        // rotate the player

        if (_direction.magnitude > 0)
        {
            transform.LookAt(worldPos);
            _targetRotation = Quaternion.LookRotation(_direction);
            transform.rotation = Quaternion.Lerp(transform.rotation, _targetRotation, Time.deltaTime * turnSpeed);
        }
        else
        {
            transform.LookAt(worldPos);
            // _targetRotation = Quaternion.LookRotation(_direction);
            // transform.rotation = Quaternion.Lerp(transform.rotation, _targetRotation, Time.deltaTime * turnSpeed);
        }


    }

    void lookWithAltKeys(){
        // get input from the player
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        //move the player
        _direction = new Vector3(horizontalInput, 0, verticalInput);
        //run or walk based on shift key
        if (Input.GetKey(KeyCode.LeftShift))
        {
            _controller.Move(_direction * runSpeed * Time.deltaTime);
        }
        else
        {
            _controller.Move(_direction * speed * Time.deltaTime);
        }

        //rotate the player
        if (Input.GetKey(RotateLeft))
        {
            transform.Rotate(Vector3.down * rotateSpeed * Time.deltaTime);
        }
        if (Input.GetKey(RotateRight))
        {
            transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);
        }


      

    }

    //create a method for knife
    void knife()
    {
        //check if player can knife
        if (_canKnife)
        {
            //activate knife child component named meleeWeapon
            transform.Find(meleeWeapon).gameObject.SetActive(true);
            //start cooldown
            StartCoroutine(knifeCooldownTimer());
            //set can knife to false
            _canKnife = false;
        }
    }

    //create a method for knife cooldown
    IEnumerator knifeCooldownTimer()
    {
        //wait for knife cooldown
        yield return new WaitForSeconds(knifeCooldown);
        //set can knife to true
        _canKnife = true;
        //deactivate knife child component named meleeWeapon
        transform.Find(meleeWeapon).gameObject.SetActive(false);
    }


    //create a method for dash
    void dash()
    {
        //check if player can dash
        if (_canDash)
        {
            //move player
            _controller.Move(_direction * dashDistance );

            //start cooldown
            StartCoroutine(dashCooldownTimer());
            //set can dash to false
            _canDash = false;
        }
    }

    //create a method for dash cooldown
    IEnumerator dashCooldownTimer()
    {
        //wait for dash cooldown
        yield return new WaitForSeconds(dashCooldown);
        //set can dash to true
        _canDash = true;
    }


    


}

