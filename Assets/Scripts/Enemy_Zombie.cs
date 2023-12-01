using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Zombie : MonoBehaviour
{
    private Animator mAnimator;
    private float mIdleTime = 0.0f;
    private float mIdleTimeMax = 5.0f;
    private float mWalkTime = 0.0f;
    private float mWalkTimeMax = 15.0f;

    
    private float rotation = 0.0f;

    private float maxRotation = 180.0f;

    private float rotationPerFrame;

    public float rotationSmoothing = 0.1f;


    public float walkSpeed = 1.0f;

    private Transform parentTransform;

    private Enemy1 enemy1;


    // private bool attackAnimationPlayed = false;
    // private bool walkAnimationPlayed = false;



    // Start is called before the first frame update
    void Start()
    {
        mAnimator = GetComponent<Animator>();
        setIdle();

        //get the Enemy1 script in parent
        enemy1 = GetComponentInParent<Enemy1>();

        //get the root parent transform
        parentTransform = transform.root;
        
    }

    // Update is called once per frame
    void Update()
    {

        if (enemy1 == null)
        {
          IdleState();
          return;
        }

        //check if enemy1.isFollowing is true but first check if enemy1 is in attack range

        if (enemy1.isAttacking == true)
        {
            mAnimator.SetTrigger("TrAttack");
            return;
        }

        if (enemy1.isFollowing == true)
        {
            mAnimator.SetTrigger("TrRun");
            return;
        }
        else
        {
            IdleState();
        }
        
    }

    void IdleState(){
        //if the idle time is greater than 0
        if (mIdleTime > 0)
        {
            //subtract the time since the last frame from the idle time
            mIdleTime -= Time.deltaTime;

            //perform rotation
            parentTransform.rotation = Quaternion.Slerp(parentTransform.rotation, Quaternion.Euler(0.0f, rotation, 0.0f), rotationSmoothing);

            //if the idle time is less than or equal to 0
            if (mIdleTime <= 0)
            {
                //call the setWalk function
                setWalk();
            }
        }
        //if the walk time is greater than 0
        else if (mWalkTime > 0)
        {
            //subtract the time since the last frame from the walk time
            mWalkTime -= Time.deltaTime;

            //move the zombie forward
            parentTransform.position += parentTransform.forward * walkSpeed * Time.deltaTime;


            //if the walk time is less than or equal to 0
            if (mWalkTime <= 0)
            {
                //call the setIdle function
                setIdle();
            }
        }
    }

    //declare a function called setIdle that randomly sets the idle time
    void setIdle()
    {
        mIdleTime = Random.Range(0.0f, mIdleTimeMax);
        mAnimator.SetTrigger("TrIdle");
        
        //randomize the rotation
        rotation = Random.Range(0.0f, maxRotation);

        //set per frame rotation
        rotationPerFrame = rotation / mIdleTime;



        //set the rotation of the zombie
        //transform.rotation = Quaternion.Euler(0.0f, rotation, 0.0f);
    }

    //declare a function called setWalk that randomly sets walk time
    void setWalk()
    {
        mWalkTime = Random.Range(0.0f, mWalkTimeMax);
        mAnimator.SetTrigger("TrWalk");
    }
}
