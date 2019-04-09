//Written by Dan Sheshtanov
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RitualEvent : MonoBehaviour
{
    public GameObject player;
    public GameObject cutCam;
    public GameObject ritualCutscene;
    public GameObject shutterToOpen;
    public GameObject stabbySpirit;
    public Transform stabbySpiritTargetPos;
    public Transform playerEndPos;
    public GameObject particles;
    public Image blackOverlay;
    public GameObject trapdoor;
    public Transform openPos;
    public List<GameObject> doorsToOpen;
    public GameObject inventory;

    public float stabbySpiritSpeed;
    public float fadeSpeed = 1;

    public float openCurtainTime = 1;
    public float queueStabbySpritWalkTime = 1;
    public float particleTime = 1;
    public float fadeOutTime = 1;
    public float fadeInTime = 1;
    public float endTime = 1;

    private bool hasBegun = false;
    private bool OpenCurtain = false;
    private bool QueueStabbySpiritWalk = false;
    private bool particleEmit = false;
    private bool FadeOut = false;
    private bool FadeIn = false;
    private bool End = false;


    private void Update()
    {
        if(Input.GetButtonDown("Cancel") && hasBegun) //if player skips this cutscene make sure it plays out right
        {
            End = true;
        }

        if (OpenCurtain)
        {
            shutterToOpen.GetComponent<ShutterMovement>().ToggleState(); //open shutter
            OpenCurtain = false;
        }
        if (QueueStabbySpiritWalk)
        {
            //spirit walks towards player
            stabbySpirit.transform.position = Vector3.Lerp(stabbySpirit.transform.position, stabbySpiritTargetPos.position, stabbySpiritSpeed * Time.deltaTime);
        }
        if (particleEmit)
        {
            //particles begin emitting
            particles.SetActive(true);
            particleEmit = false;
        }
        if (FadeOut)
        {
            QueueStabbySpiritWalk = false; //spirit stops walking towards player
            //screen begins to fade out
            blackOverlay.color = new Color(0, 0, 0, Mathf.Lerp(blackOverlay.color.a, 1, fadeSpeed * Time.deltaTime));
        }
        if (FadeIn)
        {
            //screen begines to fade in
            FadeOut = false;
            blackOverlay.color = new Color(0, 0, 0, Mathf.Lerp(blackOverlay.color.a, 0, (fadeSpeed * Time.deltaTime) / 3));
        }
        if(End)
        {
            //player can carry on playing
            FadeIn = false;
            blackOverlay.color = new Color(0, 0, 0, 0); // make sure black out overlay is gone
            player.transform.position = playerEndPos.position;
            player.transform.rotation = playerEndPos.rotation;
            //Open the basement trapdoor
            trapdoor.transform.SetPositionAndRotation(openPos.position, openPos.rotation);
            //Open the chapel doors
            foreach (GameObject door in doorsToOpen) {
                if (door.GetComponent<DoorRotate>() != null) {
                    door.GetComponent<DoorRotate>().opening = true;
                    door.layer = 1 << 0;
                }
            }
            //Remove the book
            inventory.GetComponent<inventorySelectScript>().dropBook();
            player.GetComponent<PlayerMovement>().SetPitch(0);
            Destroy(gameObject); //remove all ritual gameobjects
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!hasBegun) //can only be triggered once check
        {
            if (other.gameObject == player)
            {
                hasBegun = true;
                cutCam.GetComponent<cutsceneHandler>().StartCutscene(ritualCutscene);
                GetComponent<BoxCollider>().enabled = false;
                StartCoroutine(eventTimers());
            }
        }
    }

    private IEnumerator eventTimers()
    {
        yield return new WaitForSeconds(openCurtainTime);
        OpenCurtain = true;
        yield return new WaitForSeconds(queueStabbySpritWalkTime);
        QueueStabbySpiritWalk = true;
        yield return new WaitForSeconds(particleTime);
        particleEmit = true;
        yield return new WaitForSeconds(fadeOutTime);
        FadeOut = true;
        yield return new WaitForSeconds(fadeInTime);
        FadeIn = true;
        player.transform.position = playerEndPos.position;
        player.transform.rotation = playerEndPos.rotation;
        player.GetComponent<PlayerMovement>().SetPitch(0);
        yield return new WaitForSeconds(endTime);
        End = true;
    }
}
