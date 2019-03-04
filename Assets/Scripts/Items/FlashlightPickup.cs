using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightPickup : MonoBehaviour
{
    public GameObject flashlight;
    public GameObject flashlightSlot;

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "Player")
        {
            flashlight.GetComponent<Flashlight>().parent = flashlightSlot;
        }
    }
}
