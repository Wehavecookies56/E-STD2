using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class controllerMenuScript : MonoBehaviour
{
    public GameObject[] buttons;

    private int counter = 0;
    private bool complateMove = false;

    public Sprite selected;
    public Sprite notselected;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("JoystickDpadY") < -0.3f)
        {

            if (complateMove == false)
            {
                counter++;
                complateMove = true;
            }
            if (counter > 2) counter = 0;
        }
        if (Input.GetAxis("JoystickDpadY") > 0.3f)
        {
            if (complateMove == false)
            {
                counter--;
                complateMove = true;
            }
            if (counter < 0) counter = 2;
        }

        if (Input.GetAxis("JoystickDpadY") < 0.3f && Input.GetAxis("JoystickDpadY") > -0.3f)
        {
            complateMove = false;
        }

        CounterSwitch();

        if (Input.GetButtonDown("Fire3"))
        {
            Time.timeScale = 1;
            gameObject.SetActive(false);
        }

        if(Input.GetButtonDown("Fire1"))
        {
            switch (counter)
            {
                case 0:
                    gameObject.GetComponent<mainMenuButtons>().returnButton();
                    break;

                case 1:
                    gameObject.GetComponent<mainMenuButtons>().quitButton();
                    break;

                case 2:
                    gameObject.GetComponent<mainMenuButtons>().mainMenuButton();
                    break;
            }
        }
    }

    public void CounterSwitch()
    {
        switch (counter)
        {
            case 0:
                hightlightButton(0);
                break;

            case 1:
                hightlightButton(1);
                break;

            case 2:
                hightlightButton(2);
                break;
        }
    }

    public void hightlightButton(int counter)
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].GetComponent<Image>().sprite = notselected;
        }

        buttons[counter].GetComponent<Image>().sprite = selected;
    }
}
