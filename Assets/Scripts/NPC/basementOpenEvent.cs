using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basementOpenEvent : MonoBehaviour {

    public GameObject trapDoor;

    public GameObject oldMan;
    public GameObject boy;
    public GameObject lawyer;

    public GameObject trapDoorNewPos;

    public GameObject oldManNewPos;
    public GameObject boyNewPos;
    public GameObject lawyerNewPos;
    public List<GameObject> doors;

    public GameObject cutsceneCollider;

    Animator oldManAnim;
    Animator boyAnim;
    Animator lawyerAnim;

    AIMovement oldManAI;
    AIMovement boyAI;
    AIMovement lawyerAI;

    void Start() {
        oldManAnim = oldMan.GetComponent<Animator>();
        boyAnim = boy.GetComponent<Animator>();
        lawyerAnim = lawyer.GetComponent<Animator>();

        oldManAI = oldMan.GetComponent<AIMovement>();
        boyAI = boy.GetComponent<AIMovement>();
        lawyerAI = lawyer.GetComponent<AIMovement>();
    }

    public void doEvent() {
        oldManAI.enabled = false;
        boyAI.enabled = false;
        lawyerAI.enabled = false;
        oldMan.GetComponent<npcTalk>().enabled = false;
        boy.GetComponent<npcTalk>().enabled = false;
        lawyer.GetComponent<npcTalk>().enabled = false;
        oldMan.layer = 1 << 0;
        boy.layer = 1 << 0;
        lawyer.layer = 1 << 0;
        oldMan.GetComponent<AIController>().enabled = false;
        boy.GetComponent<AIController>().enabled = false;
        lawyer.GetComponent<AIController>().enabled = false;
        trapDoor.transform.SetPositionAndRotation(trapDoorNewPos.transform.position, trapDoorNewPos.transform.rotation);
        oldMan.transform.SetPositionAndRotation(oldManNewPos.transform.position, oldManNewPos.transform.rotation);
        boy.transform.SetPositionAndRotation(boyNewPos.transform.position, boyNewPos.transform.rotation);
        lawyer.transform.SetPositionAndRotation(lawyerNewPos.transform.position, lawyerNewPos.transform.rotation);
        oldManAnim.SetFloat("movespeed", 0);
        boyAnim.SetFloat("movespeed", 0);
        boyAnim.SetBool("running", false);
        lawyerAnim.SetFloat("movespeed", 0);
        //Open the living room doors
        foreach (GameObject door in doors) {
            if (door.GetComponent<DoorRotate>() != null) {
                door.GetComponent<DoorRotate>().opening = true;
                door.layer = 1 << 0;
            }
        }
        soundManagerScript.audioPlayer.playOnce(soundManagerScript.enviromentSounds.SCREAM, transform);
        cutsceneCollider.SetActive(true);
    }
}
