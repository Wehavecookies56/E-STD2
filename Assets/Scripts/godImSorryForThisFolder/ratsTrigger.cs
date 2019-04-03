using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ratsTrigger : MonoBehaviour
{
    public Objectives objectives;
    private float timer = 5;
    private bool go = false;

    private void Update()
    {
        if(go)
        {
            if(timer <= 0)
            {
                soundManagerScript.audioPlayer.dialogPlay(soundManagerScript.Priest.PRARE1, GameObject.FindGameObjectWithTag("Player").transform);
                gameObject.SetActive(false);
            }
            else { timer -= Time.deltaTime; }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            soundManagerScript.audioPlayer.dialogPlay(soundManagerScript.demonSounds.RATS, gameObject.transform);
            go = true;
            objectives.ActivateObjective(Objectives.ObjectivesEnum.TalkToOldMan);
            Destroy(gameObject.GetComponent<BoxCollider>());
        }
    }

    
}
