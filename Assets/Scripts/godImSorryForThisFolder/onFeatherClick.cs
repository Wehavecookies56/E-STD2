using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onFeatherClick : MonoBehaviour
{
    public void onClick()
    {
        GameObject.FindGameObjectWithTag("description").GetComponent<descriptionManager>().activateDescription(descriptionManager.descriptionType.FEATHER);
        soundManagerScript.audioPlayer.playOnce(soundManagerScript.UIsounds.BUTTONCLICKED, gameObject.transform);
    }
}
