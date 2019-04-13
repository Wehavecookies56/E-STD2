using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mirrorOnClick : MonoBehaviour
{
    public GameObject inventory;
    public GameObject candle;
    private Transform startPos;
    public Transform endPos;
    public Objectives objectives;
    private bool go = false;
    private bool speak = true;

    private void Start()
    {
        startPos = candle.transform;
        candle.SetActive(false);
        
    }

    private void Update()
    {
        if(go)
        {
            candle.SetActive(true);
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
        if(inventory.GetComponent<inventorySelectScript>().isThereA(items.ARMOUR))
        {
            go = true;
            objectives.CompleteObjective(Objectives.ObjectivesEnum.FindMirrorItem);
            inventory.GetComponent<inventorySelectScript>().deleteItem(items.ARMOUR);        
        }
        else
        {
            if(speak)
            {
                soundManagerScript.audioPlayer.dialogPlay(soundManagerScript.demonSounds.WHATINEED, transform);
                speak = false;
                objectives.ActivateObjective(Objectives.ObjectivesEnum.FindMirrorItem);
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
