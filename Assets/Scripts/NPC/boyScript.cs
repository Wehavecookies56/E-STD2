using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boyScript : MonoBehaviour {

    Animator anim;

    void Start() {
        anim = GetComponent<Animator>();
    }

    public void moveOffChair() {
        transform.Translate(0, 0, 1);
    }

}
