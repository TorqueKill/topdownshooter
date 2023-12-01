using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieIdle : MonoBehaviour
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



    // Start is called before the first frame update
    void Start()
    {
        mAnimator = GetComponent<Animator>();
        setIdle();
        
    }

    // Update is called once per frame
    void Update()
    {

        IdleState();
        
    }

    void IdleState(){
        //if the idle time is greater than 0
        if (mIdleTime > 0)
        {
            //subtract the time since the last frame from the idle time
            mIdleTime -= Time.deltaTime;

            //perform rotation
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0.0f, rotation, 0.0f), rotationSmoothing);

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
