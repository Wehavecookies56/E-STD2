﻿//Written by Dan Sheshtanov
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
    public GameObject player;
    public float playerFollowPadding;
    public LayerMask playerLOSLayer;

    private const float mansionMinX = -27.5f;
    private const float mansionMaxX = 41f;
    private const float mansionMinY = 0.75f;
    private const float mansionMaxY = 8.75f;
    private const float mansionMinZ = -135f;
    private const float mansionMaxZ = -76f;

    //private data
    private bool isFollowingPlayer = false;
    private bool isPatrolling = false;
    private bool timeToCheckPathAgain = true;
    private float minWaitBetweenPathfindingForFollowingTimer = 2.0f;

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
        //of set to follow player
        if (isFollowingPlayer)
        {
            //if close enough to the player, then don't try to follow
            if(Vector3.Distance(transform.position, player.transform.position) < playerFollowPadding) { anim.SetFloat("movespeed", 0); return; }

            //update animation
            anim.SetFloat("movespeed", mover.speed * Time.deltaTime);

            RaycastHit hit;
            Physics.Raycast(transform.position, (player.transform.position - transform.position), out hit, /*max dist to please overload*/100000f, playerLOSLayer, QueryTriggerInteraction.Ignore);
            //check if able to follow player directly or need to rely on pathfinding
            Debug.Log(hit.collider.gameObject.name);
            if(hit.collider.gameObject == player)
            {
                mover.WalkTowardsLocation(player.transform.position);
            }
            else
            {
                //if allowed to run pathfinding again, rerun the algorithm
                if (timeToCheckPathAgain)
                {
                    mover.GoToLocation(player.transform.position, playerLOSLayer);
                    timeToCheckPathAgain = false;
                    StartCoroutine(FollowPathfinderWaitTimer());
                }
                //walk towards whatever path is currently present
                mover.WalkTowardsPath();
            }
        }
        //if there is a path to go to
        else if (mover.getMovementPath().Count > 0)
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
        mover.ClearMovementPath();
    }

    public void StopPatrolling()
    {
        isPatrolling = false;
        mover.ClearMovementPath();
    }

    public void BeginFollowingPlayer()
    {
        isFollowingPlayer = true;
        mover.ClearMovementPath();
    }

    public void StopFollowingPlayer()
    {
        isFollowingPlayer = false;
        mover.ClearMovementPath();
    }

    private IEnumerator FollowPathfinderWaitTimer()
    {
        yield return new WaitForSeconds(minWaitBetweenPathfindingForFollowingTimer);
        timeToCheckPathAgain = true;
    }
}
