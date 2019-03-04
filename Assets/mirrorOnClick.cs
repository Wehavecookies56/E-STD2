using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mirrorOnClick : MonoBehaviour
{
    public GameObject inventory;
    public GameObject candle;
    private Transform startPos;
    public Transform endPos;
    private bool go = false;
    private bool speak = true;

    private void Start()
    {
        startPos = candle.transform;
        
    }

    private void Update()
    {
        if(go)
        {
            candle.transform.position = Vector3.Lerp(startPos.position, endPos.position, 0.1f);

            if (Vector3.Distance(candle.transform.position, endPos.position)<0.02f)
            {
                candle.AddComponent<Rigidbody>();
                candle.GetComponent<Rigidbody>().freezeRotation = true;
                go = false;
            }
        }

        
        
    }

    public void OnClick()
    {   
        if(inventory.GetComponent<inventorySelectScript>().isThereArmour())
        {
            go = true;
            inventory.GetComponent<inventorySelectScript>().deleteArmour();
            
        }
        else
        {
            if(speak)
            {
                soundManagerScript.audioPlayer.dialogPlay(soundManagerScript.demonSounds.WHATINEED, transform);
                speak = false;
                StartCoroutine(resetSpeak());
            }
            
        }
    }

    IEnumerator resetSpeak()
    {
        yield return new WaitForSeconds(1.5f);
        speak = true;
    }

}
