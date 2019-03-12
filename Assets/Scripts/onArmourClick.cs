using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onArmourClick : MonoBehaviour
{
    public void onClick()
    {
        GameObject.FindGameObjectWithTag("description").GetComponent<descriptionManager>().activateDescription(descriptionManager.descriptionType.ARMOUR);
        soundManagerScript.audioPlayer.playOnce(soundManagerScript.UIsounds.BUTTONCLICKED, gameObject.transform);
    }
}

