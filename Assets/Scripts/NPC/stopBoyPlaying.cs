using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stopBoyPlaying : MonoBehaviour {

    public GameObject boy;
    public GameObject pianoSound;
    public Objectives objectives;
    Animator anim;

    private float rotSpeed = 100f;
    private bool isRotating = false;

    private float startingRot;

    void Start() {
        anim = boy.GetComponent<Animator>();
        startingRot = boy.transform.rotation.eulerAngles.y;
    }

    private void Update()
    {
        if(isRotating)
        {
            boy.transform.Rotate(Vector3.up, rotSpeed * Time.deltaTime);
            if(startingRot - boy.transform.rotation.eulerAngles.y < 180 && startingRot - boy.transform.rotation.eulerAngles.y > 0)
            {
                isRotating = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player")) {
            isRotating = true;
            anim.SetTrigger("stand");
            objectives.CompleteObjective(Objectives.ObjectivesEnum.FindBoy);
            objectives.ActivateObjective(Objectives.ObjectivesEnum.TalkToBoy);
            Destroy(pianoSound);
        }
    }
}
