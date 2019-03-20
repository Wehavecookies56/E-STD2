﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class uiControler : MonoBehaviour
{
    public GameObject deathPannel;

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
        sanityColour.a = 0.6f - (playerData.INSTANCE.Sanity / 10);
        sanityPannel.GetComponent<Image>().color = sanityColour;
        sanityColour = sanityDrain.GetComponent<Image>().color;
        sanityColour.a = 1 - (playerData.INSTANCE.Sanity / 10);
        sanityDrain.GetComponent<Image>().color = sanityColour;
        */

    }


    private void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(menu.activeSelf == false)
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
    }

}


