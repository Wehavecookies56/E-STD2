using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npcKinematismSwitch : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.transform.parent != null) //if has a parent
        {
            if(other.gameObject.transform.parent.name == "NPCs") //if parent is NPC container
            {
                other.gameObject.GetComponent<Rigidbody>().isKinematic = true; //can determine that is an NPC, make kinematic
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.transform.parent != null) //if has a parent
        {
            if (other.gameObject.transform.parent.name == "NPCs") //if parent is NPC container
            {
                other.gameObject.GetComponent<Rigidbody>().isKinematic = false; //can determine that is an NPC, make not kinematic
            }
        }
    }
}
