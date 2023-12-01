using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Ghould : MonoBehaviour
{

    public Animation anim;
    public Enemy1 enemy1;



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


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animation>();
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
           return;
        }

        //check if enemy1.isFollowing is true but first check if enemy1 is in attack range

        if (enemy1.isAttacking == true)
        {
            anim.Play("Attack1");
            return;
        }

        if (enemy1.isFollowing == true)
        {
            anim.Play("Run");

        }
        else
        {
            IdleState();
        }

        
        
        
    }

    //if enemy is not following player set idle state where enemy perform idle,walk,rotations
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
                setWalk();
            }
        }
        //if the walk time is greater than 0
        else if (mWalkTime > 0)
        {
            //subtract the time since the last frame from the walk time
            mWalkTime -= Time.deltaTime;

            //perform walk step
            parentTransform.Translate(Vector3.forward * walkSpeed * Time.deltaTime);

            //if the walk time is less than or equal to 0
            if (mWalkTime <= 0)
            {
                setIdle();
            }
        }
    }

    void setIdle()
    {
        //set the idle time to a random value between 0 and the max idle time
        mIdleTime = Random.Range(0.0f, mIdleTimeMax);

        //randomize the rotation
        rotation = Random.Range(0.0f, maxRotation);

        //set the rotation per frame to a random value between 0 and the max rotation divided by the max idle time
        rotationPerFrame = rotation / mIdleTimeMax;

        anim.Play("Idle");

    }

    void setWalk()
    {
        //set the walk time to a random value between 0 and the max walk time
        mWalkTime = Random.Range(0.0f, mWalkTimeMax);

        anim.Play("Walk");
    }
}
