using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toggleTerrain : MonoBehaviour {

    public bool enable;
    public GameObject terrain;

    private void OnTriggerEnter(Collider other) {
        terrain.SetActive(enable);
    }

}