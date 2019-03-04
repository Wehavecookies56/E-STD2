using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boyScript : MonoBehaviour {

    Animator anim;
    Rigidbody rb;

    void Start() {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    void Update() {
        
    }

    public void stand() {
        anim.SetTrigger("stand");

    }
}
