using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlesMenu : MonoBehaviour
{
    public GameObject controller;
    public GameObject keyboard;


    // Update is called once per frame
    void Update()
    {
        //ifinput get botton down select || c
        string[] temp = Input.GetJoystickNames();

        if (temp.Length > 0)
        {
            for (int i = 0; i < temp.Length; ++i)
            {
                //Check if the string is empty or not
                if (!string.IsNullOrEmpty(temp[i]))
                {
                    keyboard.SetActive(false);
                    controller.SetActive(true);
                }
                else
                {
                    //If it is empty, controller i is disconnected
                    keyboard.SetActive(true);
                    controller.SetActive(false);

                }
            }
        }
        else
        {
            Cursor.visible = true;
        }       
    }
}
