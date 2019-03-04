using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ratsTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            soundManagerScript.audioPlayer.dialogPlay(soundManagerScript.demonSounds.RATS, gameObject.transform);
            StartCoroutine(waitThenPray());
            gameObject.SetActive(false);
        }
    }

    IEnumerator waitThenPray()
    {
        yield return new WaitForSeconds(5);
        soundManagerScript.audioPlayer.dialogPlay(soundManagerScript.Priest.PRARE1, GameObject.FindGameObjectWithTag("Player").transform);
    }
}
