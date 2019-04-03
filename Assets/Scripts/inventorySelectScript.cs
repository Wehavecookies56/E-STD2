﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum items { AXE, KEY, ARMOUR, BOOK, CANDLE, FEATHER, BLACKBOX, CRYSTALBALL };

public class inventorySelectScript : MonoBehaviour
{
    public GameObject[] slots;
    [SerializeField]
    private int counter = 0;
    private float timer;
    public float inputDeley;
    private bool complateMove = false;

    //sprites for button affect
    public Sprite notPressed;
    public Sprite highlighted;

    //axe prefab for drop
    public GameObject axePrefab;
    public GameObject featherUi;

    private void OnDisable()
    {
        Cursor.visible = false;
    }

   
    private string[] itemNames = {"axe", "key", "book", "candle", "feather", "blackBox", "crystalBall" };

    private void Update()
    {
        string[] temp = Input.GetJoystickNames();

        if (temp.Length > 0)
        {
            for (int i = 0; i < temp.Length; ++i)
            {
                //Check if the string is empty or not
                if (!string.IsNullOrEmpty(temp[i]))
                {
                    //Not empty, controller temp[i] is connected
                    Cursor.lockState = CursorLockMode.Locked;
                    Cursor.visible = false;
                }
                else
                {
                    //If it is empty, controller i is disconnected
                    //where i indicates the controller number
                    //Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                    counter = -1;
                }
            }
        }

        if (Input.GetAxis("JoystickDpadY") < -0.3f)
        {
            
            if (complateMove == false)
            {
                counter++;
                complateMove = true;
            }
            if (counter > 9) counter = 0;
        }
        if (Input.GetAxis("JoystickDpadY") > 0.3f)
        {
            if (complateMove == false)
            {
                counter--;
                complateMove = true;
            }
            if (counter < 0) counter = 9;
        }

        if(Input.GetAxis("JoystickDpadY") < 0.3f && Input.GetAxis("JoystickDpadY") > -0.3f)
        {
            complateMove = false;
        }

        if(Input.GetButtonDown("Fire1"))
        {
            if (counter > -1)
            if (slots[counter].transform.childCount != 0)
            {
                if (slots[counter].transform.GetChild(0).CompareTag("axe"))
                    slots[counter].transform.GetChild(0).GetComponent<onAxeClick>().onClick();

                if (slots[counter].transform.GetChild(0).CompareTag("key"))
                    slots[counter].transform.GetChild(0).GetComponent<onkeyClick>().onClick();

                if (slots[counter].transform.GetChild(0).CompareTag("armour"))
                    slots[counter].transform.GetChild(0).GetComponent<onArmourClick>().onClick();

                if (slots[counter].transform.GetChild(0).CompareTag("book"))
                    slots[counter].transform.GetChild(0).GetComponent<onBookClick>().onClick();

                if (slots[counter].transform.GetChild(0).CompareTag("candle"))
                    slots[counter].transform.GetChild(0).GetComponent<onCandleClick>().onClick();

                if (slots[counter].transform.GetChild(0).CompareTag("feather"))
                    slots[counter].transform.GetChild(0).GetComponent<onFeatherClick>().onClick();

                if (slots[counter].transform.GetChild(0).CompareTag("blackBox"))
                    slots[counter].transform.GetChild(0).GetComponent<onClickBlackBox>().onClick();

                if (slots[counter].transform.GetChild(0).CompareTag("crystalBall"))
                    slots[counter].transform.GetChild(0).GetComponent<onCrystalBallClick>().onClick();

                 

}
        }

        /*
        if(Input.GetButtonDown("Fire3"))
        {
            Time.timeScale = 1;
            soundManagerScript.audioPlayer.playOnce(soundManagerScript.UIsounds.BUTTONCLICKED, gameObject.transform);
            //gameObject.SetActive(false);
        }
        */

        switchControl();

    }
    private void spinTheChild(int index)
    {
       
        for (int i = 0; i < slots.Length; i++)
        {
            if(slots[i].transform.childCount != 0)
            {
                slots[i].GetComponentInChildren<spinItem>().go = false;
            }

            slots[i].GetComponent<Image>().sprite = notPressed;
        }

        if (slots[index].transform.childCount != 0)
        {
            slots[index].GetComponentInChildren<spinItem>().go = true;
            
        }

        slots[index].GetComponent<Image>().sprite = highlighted;
    }
    private void switchControl()
    {
        switch (counter)
        {

            case 0:
                spinTheChild(0);
                break;

            case 1:
                spinTheChild(1);
                break;

            case 2:
                spinTheChild(2);
                break;

            case 3:
                spinTheChild(3);
                break;

            case 4:
                spinTheChild(4);
                break;

            case 5:
                spinTheChild(5);
                break;

            case 6:
                spinTheChild(6);
                break;

            case 7:
                spinTheChild(7);
                break;

            case 8:
                spinTheChild(8);
                break;

            case 9:
                spinTheChild(9);
                break;
        }
    }

    public bool isThereA(items chosenItem)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].transform.childCount != 0)
            {
                if (slots[i].transform.GetChild(0).gameObject.CompareTag(itemNames[(int)chosenItem]))
                {
                    return true;
                }
            }
        }
        return false;
    }
    public void deleteItem(items chosenItem)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].transform.childCount != 0)
            {
                if (slots[i].transform.GetChild(0).gameObject.CompareTag(itemNames[(int)chosenItem]))
                {
                    Destroy(slots[i].transform.GetChild(0).gameObject);

                    for (int ii = 0; ii < slots.Length; ii++)
                    {
                        if (slots[ii].transform.childCount != 0)
                        {
                            slots[ii].GetComponentInChildren<spinItem>().go = false;
                        }

                        slots[ii].GetComponent<Image>().sprite = notPressed;
                    }

                    break;
                }
            }

        }
    }

    public void dropAxe()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].transform.childCount != 0)
            {
                if (slots[i].transform.GetChild(0).gameObject.CompareTag("axe"))
                {
                    Destroy((slots[i].transform.GetChild(0).gameObject));
                    GameObject player = GameObject.FindGameObjectWithTag("Player");
                    Vector3 pos = new Vector3(player.transform.position.x-3f, player.transform.position.y, player.transform.position.z);
                    GameObject newAxe = Instantiate(axePrefab, pos, Quaternion.identity); //drop le axe
                    playerData.INSTANCE.Strength += 1;
                    newAxe.GetComponent<Rigidbody>().AddForce(Vector3.left*300);
                    //add fire sound like a burn
                    //add an ouch dialog
                    break;  
                }
            }

        }
    }

    public void dropBook()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].transform.childCount != 0)
            {
                if (slots[i].transform.GetChild(0).gameObject.CompareTag("book"))
                {
                    Destroy((slots[i].transform.GetChild(0).gameObject));
                    playerData.INSTANCE.Intelligence -= 2;
                    break;
                }
            }

        }
    }


}
