using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenuButtons : MonoBehaviour
{
    
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
