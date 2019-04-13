using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class badendingscript : MonoBehaviour
{
    public Material redsky;
    public GameObject cutCam;
    public GameObject nodes;
    public GameObject door;
    public GameObject door2;
    public Color fogColour;
    public Color lightColour;
    public Transform lightPos;
    public GameObject dirLight;
    public GameObject UI;
    public GameObject credits;

    // Start is called before the first frame update
    void Start()
    {
        UI.SetActive(false);
        cutCam.GetComponent<cutsceneHandler>().StartCutscene(nodes);
        //doors open
        //chaange skybox
        RenderSettings.skybox = redsky;
        door.SetActive(false);
        door2.SetActive(false);
        StartCoroutine(waitThenSpek());
        StartCoroutine(restartGame());
        RenderSettings.fogColor = fogColour;
        dirLight.transform.rotation = lightPos.rotation;
        dirLight.GetComponent<Light>().color = lightColour;
    }

    IEnumerator waitThenSpek()
    {
        yield return new WaitForSeconds(11);
        soundManagerScript.audioPlayer.dialogPlay(soundManagerScript.Priest.BADENDINGN, transform);
    }

    IEnumerator restartGame()
    {
        yield return new WaitForSeconds(30);
        credits.SetActive(true);
    }
}
