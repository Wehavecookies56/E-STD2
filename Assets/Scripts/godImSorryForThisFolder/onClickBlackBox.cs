using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onClickBlackBox : MonoBehaviour
{
    public void onClick()
    {
        GameObject.FindGameObjectWithTag("description").GetComponent<descriptionManager>().activateDescription(descriptionManager.descriptionType.BLACKBOX);
        soundManagerScript.audioPlayer.playOnce(soundManagerScript.UIsounds.BUTTONCLICKED, gameObject.transform);
    }
}
