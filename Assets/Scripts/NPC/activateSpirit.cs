using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activateSpirit : MonoBehaviour
{
    public GameObject spirit;

    private void OnTriggerEnter(Collider other) {
        spirit.SetActive(true);
    }
}
