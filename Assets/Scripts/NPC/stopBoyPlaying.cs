using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stopBoyPlaying : MonoBehaviour {

    public GameObject boy;
    public GameObject pianoSound;
    Animator anim;

    void Start() {
        anim = boy.GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player")) {
            boy.transform.Rotate(0, -180, 0);
            anim.SetTrigger("stand");
            Destroy(pianoSound);
        }
    }
}
