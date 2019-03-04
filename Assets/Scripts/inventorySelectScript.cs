using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    private void Update()
    {     
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
            if (slots[counter].transform.childCount != 0)
            {
                if(slots[counter].transform.GetChild(0).CompareTag("axe"))
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

            }
        }

        if(Input.GetButtonDown("Fire3"))
        {
            Time.timeScale = 1;
            gameObject.SetActive(false);
        }

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

    public bool isThereAKey()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].transform.childCount != 0)
            {
                if (slots[i].transform.GetChild(0).gameObject.CompareTag("key"))
                {
                    return true;
                }
            }
            
        }

        return false;
    }

    public bool isThereArmour()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].transform.childCount != 0)
            {
                if (slots[i].transform.GetChild(0).gameObject.CompareTag("armour"))
                {
                    return true;
                }
            }

        }

        return false;
    }

    public bool isThereAxe()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].transform.childCount != 0)
            {
                if (slots[i].transform.GetChild(0).gameObject.CompareTag("axe"))
                {
                    return true;
                }
            }

        }

        return false;
    }

    public void deleteKey()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].transform.childCount != 0)
            {
                if (slots[i].transform.GetChild(0).gameObject.CompareTag("key"))
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

    public void deleteArmour()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].transform.childCount != 0)
            {
                if (slots[i].transform.GetChild(0).gameObject.CompareTag("armour"))
                {
                    Destroy(slots[i].transform.GetChild(0).gameObject);

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
                    Instantiate(axePrefab, pos, Quaternion.identity); //drop le axe
                    //dropped axe cant be picked up
                    break;  
                }
            }

        }
    }
}
