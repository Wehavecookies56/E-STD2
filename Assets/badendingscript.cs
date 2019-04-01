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
    
    // Start is called before the first frame update
    void Start()
    {
        cutCam.GetComponent<cutsceneHandler>().StartCutscene(nodes);
        //doors open
        //chaange skybox
        RenderSettings.skybox = redsky;
        door.SetActive(false);
        door2.SetActive(false);
        StartCoroutine(waitThenSpek());
        StartCoroutine(restartGame()); 
        
    }

    IEnumerator waitThenSpek()
    {
        yield return new WaitForSeconds(11);
        soundManagerScript.audioPlayer.dialogPlay(soundManagerScript.Priest.BADENDINGN, transform);
    }

    IEnumerator restartGame()
    {
        yield return new WaitForSeconds(30);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
