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






    // Start is called before the first frame update
    void Start()
    {
        mAnimator = GetComponent<Animator>();
        setIdle();
        
    }

    // Update is called once per frame
    void Update()
    {
        //if the idle time is greater than 0
        if (mIdleTime > 0)
        {
            //subtract the time since the last frame from the idle time
            mIdleTime -= Time.deltaTime;
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

        //print the idle time and walk time to the console
        //Debug.Log("Idle Time: " + mIdleTime + " Walk Time: " + mWalkTime);
        
    }

    //declare a function called setIdle that randomly sets the idle time
    void setIdle()
    {
        mIdleTime = Random.Range(0.0f, mIdleTimeMax);
        mAnimator.SetTrigger("TrIdle");
    }

    //declare a function called setWalk that randomly sets walk time
    void setWalk()
    {
        mWalkTime = Random.Range(0.0f, mWalkTimeMax);
        mAnimator.SetTrigger("TrWalk");
    }
}
