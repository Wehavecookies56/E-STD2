using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShutterNPCCollisionBehaviour : MonoBehaviour
{
    //container object for NPCs, used to check if collision was with an NPC
    public string NPCContainerName = "NPCs";

    private void OnCollisionEnter(Collision collision)
    {
        //NPCs are within an NPC container object, test that
        if (collision.transform.parent != null)
        {
            //test if within the NPC container gameobject
            if(collision.transform.parent.name == NPCContainerName)
            {
                //check that it's closed
                if(!GetComponent<ShutterMovement>().isOpen())
                {
                    //all checks are good, toggle state
                    GetComponent<ShutterMovement>().ToggleState();
                }
            }
        }
    }
}
