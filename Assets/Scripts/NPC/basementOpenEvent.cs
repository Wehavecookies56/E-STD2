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

    Animator oldManAnim;
    Animator boyAnim;
    Animator lawyerAnim;

    TestAI oldManAI;
    TestAI boyAI;
    TestAI lawyerAI;

    void Start() {
        oldManAnim = oldMan.GetComponent<Animator>();
        boyAnim = boy.GetComponent<Animator>();
        lawyerAnim = lawyer.GetComponent<Animator>();

        oldManAI = oldMan.GetComponent<TestAI>();
        boyAI = boy.GetComponent<TestAI>();
        lawyerAI = lawyer.GetComponent<TestAI>();
    }

    public void doEvent() {
        oldManAI.enabled = false;
        boyAI.enabled = false;
        lawyerAI.enabled = false;
        trapDoor.transform.SetPositionAndRotation(trapDoorNewPos.transform.position, trapDoorNewPos.transform.rotation);
        oldMan.transform.SetPositionAndRotation(oldManNewPos.transform.position, oldManNewPos.transform.rotation);
        boy.transform.SetPositionAndRotation(boyNewPos.transform.position, boyNewPos.transform.rotation);
        lawyer.transform.SetPositionAndRotation(lawyerNewPos.transform.position, lawyerNewPos.transform.rotation);
        oldManAnim.SetFloat("movespeed", 0);
        boyAnim.SetFloat("movespeed", 0);
        lawyerAnim.SetFloat("movespeed", 0);
    }
}
