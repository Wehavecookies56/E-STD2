//Script written by Dan Sheshtanov
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderPlayer : MonoBehaviour
{
    //player reference
    GameObject player;
    //particle system component reference
    ParticleSystem ps;
    //array to hold lightning particles, there can only ever be 1 at a time
    ParticleSystem.Particle[] particles = new ParticleSystem.Particle[1];
    //controls audio call to be once per particle
    bool needReset = false;
    
    void Start()
    {
        player = GameObject.Find("Player");
        ps = GetComponent<ParticleSystem>();
    }

    void Update()
    {
        int numOfParticles = ps.GetParticles(particles);

        if (!needReset) //if particle hasn't already been detected
        {
            if (numOfParticles > 0)
            {
                needReset = true;
                soundManagerScript.enviromentSounds thunderSound;
                int randomIndex = Random.Range((int)0, (int)4);

                switch (randomIndex)
                {
                    case 0: thunderSound = soundManagerScript.enviromentSounds.THUNDER1;
                        soundManagerScript.audioPlayer.playOnce(thunderSound, player.transform);
                        break;
                    case 1:
                        thunderSound = soundManagerScript.enviromentSounds.THUNDER2;
                        soundManagerScript.audioPlayer.playOnce(thunderSound, player.transform);
                        break;
                    case 2:
                        thunderSound = soundManagerScript.enviromentSounds.THUNDER3;
                        soundManagerScript.audioPlayer.playOnce(thunderSound, player.transform);
                        break;
                    case 3:
                        thunderSound = soundManagerScript.enviromentSounds.THUNDER4;
                        soundManagerScript.audioPlayer.playOnce(thunderSound, player.transform);
                        break;
                    default:
                        break;
                }
            }
        }
        else
        {
            if(numOfParticles < 1)
            {
                needReset = false;
            }
        }
        
    }
}
