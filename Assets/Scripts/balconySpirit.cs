using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class balconySpirit : MonoBehaviour {

    public GameObject shovel;

    public void dropShovel() {
        shovel.GetComponent<Rigidbody>().isKinematic = false;
        shovel.transform.parent = null;
    }

    public void uppercut() {
        transform.Rotate(new Vector3(0, 180, 0));
        GetComponent<Rigidbody>().isKinematic = false;
        transform.Translate(new Vector3(0, 0, -2.6f));
    }

    void Update() {
        
    }
}
