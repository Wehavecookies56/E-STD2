using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class breakVase : MonoBehaviour {

    public GameObject broken;
    public GameObject unbroken;
    public GameObject key;
    bool smashedIt;

    public void Break() {
        if (!smashedIt) {
            smashedIt = true;
            broken.SetActive(true);
            unbroken.SetActive(false);
            StartCoroutine(disableCollision());
            soundManagerScript.audioPlayer.playOnce(soundManagerScript.enviromentSounds.POTBREAK, transform);
            GameObject newKey = Instantiate(key);
            newKey.transform.position = transform.position;
        }
    }

    private IEnumerator disableCollision() {
        yield return new WaitForSeconds(1);
        GetComponent<BoxCollider>().enabled = false;
    }
}
