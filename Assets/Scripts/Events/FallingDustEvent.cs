//Written by Dan Sheshtanov
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingDustEvent : MonoBehaviour
{
    //component references
    private ParticleSystem ps;
    private BoxCollider bc;
    private soundManagerScript sm;
    
    void Start()
    {
        //get references
        ps = GetComponent<ParticleSystem>();
        bc = GetComponent<BoxCollider>();
        sm = GameObject.Find("soundManager").GetComponent<soundManagerScript>();
    }

    private void OnTriggerEnter(Collider other)
    {
        //if collided with player, start particle system and disable collider (single play)
        if(other.gameObject.tag == "Player")
        {
            ps.Play();
            sm.playOnce(soundManagerScript.enviromentSounds.DUSTFALLING, transform);
            bc.enabled = false;
        }
    }
}
