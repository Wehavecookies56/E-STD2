using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenuButtons : MonoBehaviour
{

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
                    Cursor.lockState = CursorLockMode.Locked;
                    Cursor.visible = false;
                }
                else
                {
                    Cursor.visible = true;
                }
            }
        }
    }

    public void returnButton()
    {
        Time.timeScale = 1;
        soundManagerScript.audioPlayer.playOnce(soundManagerScript.UIsounds.BUTTONCLICKED, gameObject.transform);
        gameObject.SetActive(false);
    }

    public void mainMenuButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().ToString());
    }

    public void quitButton()
    {
        Application.Quit();
    }
}
