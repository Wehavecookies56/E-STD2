//Written by Dan Sheshtanov
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CthulhuAI : AIController
{
    //range cthulhu needs to be in to attack
    public float attackRange;

    
    void Update()
    {
        //if in range to attack..
        if(Vector3.Distance(transform.position, player.transform.position) < attackRange)
        {
            if (!(anim.GetCurrentAnimatorStateInfo(0).IsName("strongAttack"))) //this check prevents trigger activating twice, once on first call then again when animation starts playing
            {
                anim.SetTrigger("strongAttack");
                playerData.INSTANCE.Health -= 3;
                //TODO attack here, damage player here
            }
        }
        else if (isFollowingPlayer)
        {
            anim.SetFloat("speed", mover.speed);

            heightOffset = new Vector3(0, pivotHeightOffset, 0);

            //if close enough to the player, then don't try to follow
            if (Vector3.Distance(transform.position + heightOffset, player.transform.position) < playerFollowPadding) { anim.SetFloat("speed", 0); return; }

            RaycastHit hit;
            Physics.Raycast(transform.position + heightOffset, (player.transform.position - (transform.position + heightOffset)), out hit, /*max dist to please overload*/100000f, playerLOSLayer, QueryTriggerInteraction.Ignore);
            //check if able to follow player directly or need to rely on pathfinding
            Debug.DrawRay(transform.position + heightOffset, (player.transform.position - (transform.position + heightOffset)));
            if (hit.collider.gameObject == player)
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
    }
}
