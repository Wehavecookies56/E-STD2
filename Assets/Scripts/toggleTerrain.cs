using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toggleTerrain : MonoBehaviour {

    public bool enable;
    public GameObject[] Objects;

    private void OnTriggerEnter(Collider other) {
        foreach (GameObject go in Objects)
        {
            go.SetActive(enable);
        }
    }

}