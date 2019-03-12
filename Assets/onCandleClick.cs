using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onCandleClick : MonoBehaviour
{
    public void onClick()
    {
        GameObject.FindGameObjectWithTag("description").GetComponent<descriptionManager>().activateDescription(descriptionManager.descriptionType.CANDLE);
        soundManagerScript.audioPlayer.playOnce(soundManagerScript.UIsounds.BUTTONCLICKED, gameObject.transform);
    }
}
