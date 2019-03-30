using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goodEndingScript : MonoBehaviour
{
    public Material sunny;
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
        RenderSettings.skybox = sunny;
        door.GetComponent<Animator>().enabled = true;
        door2.GetComponent<Animator>().enabled = true;
        //turn off weather
    }

    
}
