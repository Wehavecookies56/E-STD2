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


    // Start is called before the first frame update
    void Start()
    {
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
        StartCoroutine(restartGame());
    }

    IEnumerator restartGame()
    {
        yield return new WaitForSeconds(15);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    
}
