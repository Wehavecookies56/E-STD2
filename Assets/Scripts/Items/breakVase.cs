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
            playerData.INSTANCE.Sanity -= 1;
            if(key != null)
            {
                GameObject newKey = Instantiate(key);
                newKey.transform.position = transform.position;
            }
            else
            {
                soundManagerScript.audioPlayer.playOnce(soundManagerScript.enviromentSounds.STATUELAUGH, transform);
            }
        }
    }

    private IEnumerator disableCollision() {
        yield return new WaitForSeconds(1);
        GetComponent<BoxCollider>().enabled = false;
    }
}
