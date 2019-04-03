using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onBookClick : MonoBehaviour
{
    public void onClick()
    {
        GameObject.FindGameObjectWithTag("description").GetComponent<descriptionManager>().activateDescription(descriptionManager.descriptionType.BOOK);
        soundManagerScript.audioPlayer.playOnce(soundManagerScript.UIsounds.BUTTONCLICKED, gameObject.transform);
    }
}
