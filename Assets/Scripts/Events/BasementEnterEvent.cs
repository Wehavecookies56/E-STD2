//Written by Dan Sheshtanov
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasementEnterEvent : MonoBehaviour
{
    public GameObject player;
    public GameObject cutCam;
    public GameObject basementEntranceCutscene;
    public Transform playerEndPos;
    public GameObject trapdoor;
    public Transform closePos;

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            cutCam.GetComponent<cutsceneHandler>().StartCutscene(basementEntranceCutscene);
            player.transform.position = playerEndPos.position;
            player.transform.rotation = playerEndPos.rotation;
            player.GetComponent<PlayerMovement>().SetPitch(0);
            GetComponent<BoxCollider>().enabled = false;
            StartCoroutine(closeBasement());
        }
    }

    private IEnumerator closeBasement() {
        yield return new WaitForSeconds(15);
        //Close the basement trapdoor
        trapdoor.transform.SetPositionAndRotation(closePos.position, closePos.rotation);
    }
}
