using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class InteractEvent : UnityEvent<GameObject> {
    
}

public class playerInteract : MonoBehaviour
{

    public GameObject doorParts;
    public Transform playerLookCamera;
    public GameObject inv;
    //Raycast distance
    public float distance = 500;
    public GameObject lastLookedAt;
    public Objectives objectives;

    public LayerMask mask;

    [SerializeField]
    public InteractEvent onInteract;

    void Start()
    {
        if (onInteract == null)
            onInteract = new InteractEvent();
    }

    void Update()
    {
        RaycastHit rh;
        //Raycast from camera
        var r = new Ray(playerLookCamera.position, playerLookCamera.forward);
        //Raycast only for objects with items layer
        if (Physics.Raycast(r, out rh, distance, mask))
        {
            if (1 << rh.transform.gameObject.layer == 1 << LayerMask.NameToLayer("items"))
            {
                GameObject lookedAt = rh.transform.gameObject;
                lastLookedAt = lookedAt;
                //Boolean_446AB9C2 is the id for the "enabled" property in the item highlight shader
                lookedAt.GetComponent<MeshRenderer>().material.SetFloat("Boolean_446AB9C2", 1);
                if (Input.GetButtonDown("Fire1"))
                {
                    onInteract.Invoke(lookedAt);
                }
            }
            else
            {
                if (lastLookedAt != null)
                {
                    lastLookedAt.GetComponent<MeshRenderer>().material.SetFloat("Boolean_446AB9C2", 0);
                    lastLookedAt = null;
                }
            }
        }
        else
        {
            if (lastLookedAt != null)
            {
                lastLookedAt.GetComponent<MeshRenderer>().material.SetFloat("Boolean_446AB9C2", 0);
                lastLookedAt = null;
            }
        }
    }

    public void pickUpItem(GameObject item)
    {
        //Add to inventory here
        if (item.GetComponent<objectScript>().data.Type == ObjectType.PICKUP)
        {
            if (item.GetComponent<objectScript>().data.ObjectName.Equals("Book"))
            {
                soundManagerScript.audioPlayer.dialogPlay(soundManagerScript.demonSounds.IAMTHEFLOOR, item.transform);
            }
            else if (item.GetComponent<objectScript>().data.ObjectName.Equals("Black Box"))
            {
                GameObject.Find("Basement Open").GetComponent<basementOpenEvent>().doEvent();
            }
            else if (item.GetComponent<objectScript>().data.ObjectName.Equals("Armour"))
            {
                objectives.CompleteObjective(Objectives.ObjectivesEnum.InspectPiano);
                if (objectives.IsObjectiveActive(Objectives.ObjectivesEnum.FindMirrorItem))
                    objectives.CompleteObjective(Objectives.ObjectivesEnum.FindMirrorItem);
            }
            else if (item.GetComponent<objectScript>().data.ObjectName.Equals("Key"))
            {
                objectives.CompleteObjective(Objectives.ObjectivesEnum.FindKey);
            }
            else if (item.GetComponent<objectScript>().data.ObjectName.Equals("axe"))
            {
                objectives.CompleteObjective(Objectives.ObjectivesEnum.FindAxe);
            }
            item.GetComponent<InventoryItemPickUp>().pickUpItem();
        }

        if (item.GetComponent<objectScript>().data.Type == ObjectType.SEARCH)
        {
            if (item.GetComponent<objectScript>().data.ObjectName.Equals("Strange Plant"))
            {
                soundManagerScript.audioPlayer.playOnce(soundManagerScript.enviromentSounds.GHOSTSCREAM, transform);
                playerData.INSTANCE.Health -= 1;
                item.transform.GetChild(1).GetComponent<SkinnedMeshRenderer>().material.SetColor("_EmissionColor", new Color(0, 0, 0));
                item.GetComponent<BoxCollider>().enabled = false;
            }
        }
        if (item.GetComponent<objectScript>().data.Type == ObjectType.FLIP)
        {
            item.GetComponent<Animator>().SetTrigger("flip");
            objectives.CompleteObjective(Objectives.ObjectivesEnum.FlipCoin);
        }

        if (item.GetComponent<objectScript>().data.Type == ObjectType.TALK)
        {
            if (item.GetComponent<objectScript>().data.ObjectName.Equals("Morpheus"))
            {
                npcTalk t = item.GetComponent<npcTalk>();
                if (t.currentLine + 1 == t.lineCount)
                {
                    //TODO item.GetComponent<AIController>().BeginPatrolling();
                    item.GetComponent<AIController>().BeginFollowingPlayer(); //TODO testing following
                }
                t.playDialog((soundManagerScript.lawyerAndPriest)t.currentLine);
            }
            if (item.GetComponent<objectScript>().data.ObjectName.Equals("Old Man"))
            {
                npcTalk t = item.GetComponent<npcTalk>();
                if (t.currentLine + 1 == t.lineCount)
                {
                    item.GetComponent<AIController>().BeginPatrolling();
                }
                t.playDialog((soundManagerScript.oldManAndPriest)t.currentLine);
            }

            if (item.GetComponent<objectScript>().data.ObjectName.Equals("Boy"))
            {
                npcTalk t = item.GetComponent<npcTalk>();
                if (t.currentLine + 1 == t.lineCount)
                {
                    item.GetComponent<AIController>().BeginPatrolling();
                    item.GetComponent<Animator>().SetBool("running", true);
                    item.GetComponent<Rigidbody>().isKinematic = false;
                }
                t.playDialog((soundManagerScript.boyAndPriest)t.currentLine);
            }
            if (item.GetComponent<objectScript>().data.ObjectName.Equals("Devil"))
            {
                npcTalk t = item.GetComponent<npcTalk>();
                if (t.currentLine + 1 == t.lineCount)
                {


                }
                t.playDialog((soundManagerScript.boyAndPriest)t.currentLine);
            }
        }

        if (item.GetComponent<objectScript>().data.Type == ObjectType.TOUCH)
        {

            if (item.GetComponent<objectScript>().data.ObjectName.Equals("Vase") || item.GetComponent<objectScript>().data.name.Equals("Plate"))
            {
                item.GetComponent<breakVase>().Break();
            }

            if (item.GetComponent<objectScript>().data.ObjectName.Equals("mirror"))
            {
                item.GetComponent<mirrorOnClick>().OnClick();
            }

            if (item.GetComponent<objectScript>().data.ObjectName.Equals("Skull"))
            {
                playerData.INSTANCE.Sanity--;
                item.GetComponent<BoxCollider>().enabled = false;
            }

            if (item.GetComponent<objectScript>().data.ObjectName.Equals("Hanging man"))
            {
                item.SetActive(false);
                playerData.INSTANCE.Sanity -= 2;
                playerData.INSTANCE.Health -= 1;
                GameObject.FindGameObjectWithTag("dust").transform.GetChild(0).gameObject.SetActive(true);
                //add coughthing sound 
            }


        }

        if (item.GetComponent<objectScript>().data.Type == ObjectType.BURN)
        {
            if (item.GetComponent<tooltipOverride>().display)
            {
                inv.GetComponent<inventorySelectScript>().dropBook();
                item.GetComponent<BookBurnTooltipScript>().goodEnding();
            }
        }

        if (item.GetComponent<objectScript>().data.Type == ObjectType.OPEN)
        {
            if (item.GetComponent<objectScript>().data.ObjectName.Equals("Curtains"))
            {
                item.GetComponent<ShutterMovement>().ToggleState();
            }
            if (item.GetComponent<objectScript>().data.ObjectName.Equals("Door") || (item.GetComponent<objectScript>().data.ObjectName.Equals("Chest")))
            {

                if (item.GetComponent<DoorRotate>().needskey)
                {
                    if (inv.GetComponent<inventorySelectScript>().isThereA(items.KEY) == true)
                    {
                        item.GetComponent<DoorRotate>().opening = true;
                        soundManagerScript.audioPlayer.playOnce(soundManagerScript.enviromentSounds.DOOROPEN, item.transform);
                        item.layer = 1 << LayerMask.NameToLayer("Default");
                        item.GetComponent<BoxCollider>().isTrigger = true;
                        inv.GetComponent<inventorySelectScript>().deleteItem(items.KEY);
                    }
                    else { objectives.ActivateObjective(Objectives.ObjectivesEnum.FindKey); }
                }
                else if (item.GetComponent<DoorRotate>().needsAxe)
                {
                    if (inv.GetComponent<inventorySelectScript>().isThereA(items.AXE))
                    {
                        GameObject.FindGameObjectWithTag("CutsceneCamera").GetComponent<cutsceneHandler>().StartCutscene(GameObject.FindGameObjectWithTag("jhonnysDad"));
                        soundManagerScript.audioPlayer.dialogPlay(soundManagerScript.Priest.JHONNY, GameObject.FindGameObjectWithTag("Player").transform);
                        soundManagerScript.audioPlayer.playOnce(soundManagerScript.enviromentSounds.AXEIMPACT, item.transform);
                        doorParts.SetActive(true);
                        GameObject.FindGameObjectWithTag("jhonnyDoor").SetActive(false);
                        objectives.CompleteObjective(Objectives.ObjectivesEnum.DestroyDoor);
                    }
                    else { objectives.ActivateObjective(Objectives.ObjectivesEnum.DestroyDoor); }
                }
                else
                {
                    item.GetComponent<DoorRotate>().opening = true;
                    if (item.GetComponent<objectScript>().data.ObjectName.Equals("Chest"))
                    {
                        soundManagerScript.audioPlayer.playOnce(soundManagerScript.enviromentSounds.CHESTOPEN, item.transform);
                        objectives.ActivateObjective(Objectives.ObjectivesEnum.FlipCoin);
                    }
                    else
                    {
                        soundManagerScript.audioPlayer.playOnce(soundManagerScript.enviromentSounds.DOOROPEN, item.transform);
                    }

                    item.layer = 1 << LayerMask.NameToLayer("Default");
                    item.GetComponent<BoxCollider>().isTrigger = true;
                }
            }
            else if (item.GetComponent<objectScript>().data.ObjectName.Equals("Window"))
            {
                item.GetComponent<windowOpenClose>().opening = true;
                soundManagerScript.audioPlayer.playOnce(soundManagerScript.enviromentSounds.WINDOW, item.transform);
                item.layer = 1 << LayerMask.NameToLayer("Default");
            }
        }
        

    }
}

