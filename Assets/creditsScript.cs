using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class creditsScript : MonoBehaviour
{
    public GameObject cutCam;
    public GameObject parentCutScean;
    // Start is called before the first frame update
    void Start()
    {
        cutCam.GetComponent<cutsceneHandler>().StartCutscene(parentCutScean);
    }

    
}
