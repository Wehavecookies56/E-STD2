using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onCrystalBallClick : MonoBehaviour
{

    public int counter = 0;
    public void onClick()
    {
        GameObject.FindGameObjectWithTag("description").GetComponent<descriptionManager>().activateDescription(descriptionManager.descriptionType.CRYSTALBALL);
        soundManagerScript.audioPlayer.playOnce(soundManagerScript.UIsounds.BUTTONCLICKED, gameObject.transform);
        if(counter == 1)
        {
            //GameObject instance = GameObject.FindGameObjectWithTag("crystalballcam").transform.GetChild(0).GetComponent<GameObject>();
            //instance.SetActive(true);
            Time.timeScale = 1;
            GameObject.FindGameObjectWithTag("crystalballui").GetComponent<CanvasGroup>().alpha = 1;
            GameObject.FindGameObjectWithTag("crystalballui").GetComponent<CanvasGroup>().blocksRaycasts = true;
          counter = 0;
        }
        else
        {
            counter++;
        }
    }
}
