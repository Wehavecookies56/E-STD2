using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class subtitleToggle : MonoBehaviour {

    public GameObject subtitles;

    void Update() {
        if (Input.GetButton("selectButton")) {
            subtitles.SetActive(!subtitles.activeSelf);
        }
    }
}
