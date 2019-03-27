//Written by Dan Sheshtanov
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
    private const float mansionMinX = -27.5f;
    private const float mansionMaxX = 41f;
    private const float mansionMinY = 0.75f;
    private const float mansionMaxY = 8.75f;
    private const float mansionMinZ = -135f;
    private const float mansionMaxZ = -76f;

    //private data
    private bool isPatrolling;

    //references
    private AIMovement mover;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        //get a reference to the movement script
        mover = GetComponent<AIMovement>();
        //check if was retrieved
        Debug.Assert(mover);
        //get a reference to the animator
        anim = GetComponent<Animator>();
        //check if was retrieved
        Debug.Assert(anim);
    }

    // Update is called once per frame
    void Update()
    {
        //if there is a path to go to
        if (mover.getMovementPath().Count > 0)
        {
            //walk along current path
            mover.WalkTowardsPath();
            //update animation
            anim.SetFloat("movespeed", mover.speed * Time.deltaTime);
        }
        else
        {
            if (isPatrolling) //check that in patrol mode
            {
                while (mover.getMovementPath().Count < 1) //keep trying until found a valid movement path
                {
                    mover.GoToLocation(new Vector3(Random.Range(mansionMinX,mansionMaxX), Random.Range(mansionMinY,mansionMaxY), Random.Range(mansionMinZ,mansionMaxZ))); //go to a random location within the mansion bounds
                }
            }
        }
    }

    public void BeginPatrolling()
    {
        isPatrolling = true;
    }

    public void StopPatrolling()
    {
        isPatrolling = false;
        mover.ClearMovementPath();
    }
}
