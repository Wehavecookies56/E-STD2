using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plateTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            soundManagerScript.audioPlayer.dialogPlay(soundManagerScript.demonSounds.BREAKME, GameObject.FindGameObjectWithTag("plate").transform);
            gameObject.SetActive(false);
        }
    }
}
