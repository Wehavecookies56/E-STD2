using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class uiControler : MonoBehaviour
{
    public GameObject deathPannel;
    public GameObject journal;
    public GameObject getHurtPannel;
    public GameObject getHurtRed;
    private Color hurtPannelColour;

    public GameObject sanityPannel;
    public GameObject sanityDrain;
    private Color sanityColour;
    public GameObject minimap;
    

    public float hardIntesity = 0.6f;
    public float mediumIntesity = 0.4f;
    public float softIntesity = 0.2f;
    public float lerpSpeed = 0.1f;

    public GameObject menu;
    public GameObject contolerMenu;
    public GameObject inventory;

    public GameObject playerCam;

    private const float defultVig = 0.325f;
    private const float maxSanity = 10;
    private const float effectMulti = 0.25f;

    public GameObject inputsMenu;

    private void Start()
    {
        hurtPannelColour = getHurtPannel.GetComponent<Image>().color;
        sanityColour = sanityPannel.GetComponent<Image>().color;
    }

    private void FixedUpdate()
    {

        //you died screen
        if (playerData.INSTANCE.Health <= 0)
        {
            deathPannel.SetActive(true);
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().enabled = false;
        }

        //hurt ui
        hurtPannelColour.a = (1 - (playerData.INSTANCE.Health / 10));
        getHurtPannel.GetComponent<Image>().color = hurtPannelColour;
        hurtPannelColour.a = (0.6f - (playerData.INSTANCE.Health / 10));
        getHurtRed.GetComponent<Image>().color = hurtPannelColour;

        //crazy ui

        /*
        sanityColour.a = 0.325f - (playerData.INSTANCE.Sanity / 10);
        sanityPannel.GetComponent<Image>().color = sanityColour;
        sanityColour = sanityDrain.GetComponent<Image>().color;
        sanityColour.a = 1 - (playerData.INSTANCE.Sanity / 10);
        sanityDrain.GetComponent<Image>().color = sanityColour;
        */
       
        //check if playercam is active
        if (/*playerCam.GetComponent<CustomPostProcessingBehaviour>().hasBeenInitialised && */playerCam.activeSelf)
            playerCam.GetComponent<CustomPostProcessingBehaviour>().SetVignette( defultVig + ((1 - (playerData.INSTANCE.Sanity / maxSanity)) * effectMulti));

    }


    private void LateUpdate()
    {
        if (Input.GetButtonDown("Cancel" /*escape key*/))
        {
            //if in cutscene, skip cutscene and ignore input
            if (GameObject.Find("CutsceneCamera").GetComponent<cutsceneHandler>().getIsInCutsceneMode())
            {
                GameObject.Find("CutsceneCamera").GetComponent<cutsceneHandler>().SkipCutscene();
                return;
            }

            if (menu.activeSelf == false)
            {
                menu.SetActive(true);
                Time.timeScale = 0;
                soundManagerScript.audioPlayer.playOnce(soundManagerScript.UIsounds.SCROLLOPEN, gameObject.transform);
            }  
            else
            {
                menu.SetActive(false);
                Time.timeScale = 1;
            }
        }

        if(Input.GetKeyDown(KeyCode.Tab) || Input.GetButtonDown("Jump"))
        {
            if(inventory.activeSelf == false)
            {
                if (contolerMenu.activeSelf == false)
                {
                    if (menu.activeSelf == false)
                    {
                        inventory.SetActive(true);
                        Time.timeScale = 0;
                        soundManagerScript.audioPlayer.playOnce(soundManagerScript.UIsounds.SCROLLOPEN, gameObject.transform);
                    }
                   
                }               
            }
            else
            {
                Time.timeScale = 1;
                inventory.SetActive(false);
            }
        }

        if(Input.GetButtonDown("startButton"))
        {
            if(contolerMenu.activeSelf == false)
            {
                contolerMenu.SetActive(true);
                Time.timeScale = 0;
                soundManagerScript.audioPlayer.playOnce(soundManagerScript.UIsounds.SCROLLOPEN, gameObject.transform);
            }
            else
            {
                contolerMenu.SetActive(false);
                Time.timeScale = 1;
            }
           
        }

        if(Input.GetKeyDown(KeyCode.M))
        {
            //toggles image of the minimap state
            minimap.transform.GetChild(0).GetComponent<RawImage>().enabled = !minimap.transform.GetChild(0).GetComponent<RawImage>().enabled;
        }    
        
        if(Input.GetButtonDown("selectButton") || Input.GetKeyDown(KeyCode.C))
        {
            if (contolerMenu.activeSelf == false)
            {
                if (menu.activeSelf == false)
                {
                    if(inputsMenu.activeSelf == false)
                    {
                        inputsMenu.SetActive(true);
                        Time.timeScale = 0;
                        soundManagerScript.audioPlayer.playOnce(soundManagerScript.UIsounds.SCROLLOPEN, gameObject.transform);
                    }
                    else
                    {
                        inputsMenu.SetActive(false);
                        Time.timeScale = 1;
                    }
                }
            }

        }

        //j to show journal
        if(Input.GetKeyDown(KeyCode.J))
        {
            if (contolerMenu.activeSelf == false) 
            if (inputsMenu.activeSelf == false) 
            if (menu.activeSelf == false) 
            if (inventory.activeSelf == false)
               {
                       journal.GetComponent<Animator>().SetTrigger("show");
               }
        }

        if(Input.GetButtonDown("Fire3"))
        {
            Time.timeScale = 1;
            if (contolerMenu.activeSelf == true) contolerMenu.SetActive(false);               
            if (inputsMenu.activeSelf == true) inputsMenu.SetActive(false);              
            if (menu.activeSelf == true) menu.SetActive(false);
            if (inventory.activeSelf == true) inventory.SetActive(false);
        }
    }

}


