using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class goodEndingScript : MonoBehaviour
{
    public Material sunny;
    public GameObject cutCam;
    public GameObject nodes;
    public GameObject door;
    public GameObject door2;
    public GameObject weather;
    public Color fogColour;
    public GameObject UI;
    public GameObject credits;


    // Start is called before the first frame update
    void Start()
    {
        UI.SetActive(false);
        cutCam.GetComponent<cutsceneHandler>().StartCutscene(nodes);
        //doors open
        //chaange skybox
        RenderSettings.skybox = sunny;
        //change fog colour
        RenderSettings.fogColor = fogColour;
        door.SetActive(false);
        door2.SetActive(false);
        soundManagerScript.audioPlayer.dialogPlay(soundManagerScript.Priest.GOODENDING, transform);
        //turn off weather
        weather.SetActive(false);
        StartCoroutine(restartGameGood());
    }

    private void Update()
    {
       
    }

    IEnumerator restartGameGood()
    {
        yield return new WaitForSeconds(10);
        //cutCam.SetActive(false);
        //cutCam.SetActive(true);
        Application.Quit();
        credits.SetActive(true);
    }

    
}
