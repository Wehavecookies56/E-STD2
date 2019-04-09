using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activateBalconySpirit : MonoBehaviour {
    public GameObject spirit;

    private void OnTriggerEnter(Collider other) {
        spirit.SetActive(true);
        spirit.GetComponent<Animator>().SetTrigger("run");
    }
}
