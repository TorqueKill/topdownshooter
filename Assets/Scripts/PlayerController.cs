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


    private bool weapon1 = true;
    private bool weapon2 = false;
   // private bool weapon3 = false;


    private GameObject weapon1Object;

    private GameObject weapon2Object;

    //private GameObject weapon3Object;


    // Start is called before the first frame update
    void Start()
    {
        _controller = GetComponent<CharacterController>();
        cam = Camera.main;

        //weapon1 should be child of hand which is child of player
        weapon1Object = transform.Find("Hand").Find("Rifle").gameObject;

        //weapon2 should be child of hand which is child of player
        weapon2Object = transform.Find("Hand").Find("Rocket Launcher").gameObject;
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

        //check if player can switch weapons
        weaponSwitchCheck();

        //switch weapons
        switchWeapons();


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


    void weaponSwitchCheck(){

        // if 1 is pressed, set weapon1 to true and weapon2 and weapon3 to false
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            weapon1 = true;
            weapon2 = false;
            //weapon3 = false;
        }
        // if 2 is pressed, set weapon2 to true and weapon1 and weapon3 to false
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            weapon1 = false;
            weapon2 = true;
            //weapon3 = false;
        }
        // if 3 is pressed, set weapon3 to true and weapon1 and weapon2 to false
        // if (Input.GetKeyDown(KeyCode.Alpha3))
        // {
        //     weapon1 = false;
        //     weapon2 = false;
        //     weapon3 = true;
        // }

    }


    void switchWeapons(){
        if (weapon1)
        {
            weapon1Object.SetActive(true);
            weapon2Object.SetActive(false);
            //weapon3Object.SetActive(false);
        }
        else if (weapon2)
        {
            weapon1Object.SetActive(false);
            weapon2Object.SetActive(true);
            //weapon3Object.SetActive(false);
        }
        // else if (weapon3)
        // {
        //     weapon1Object.SetActive(false);
        //     weapon2Object.SetActive(false);
        //     weapon3Object.SetActive(true);
        // }
    }




    


}

