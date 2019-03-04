using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    public GameObject text;
    public GameObject cutCam;
    public GameObject startPos;
    public GameObject startCam;
    public GameObject player;
    public GameObject[] lightning;

    void Update()
    {
        if(Input.anyKeyDown == true)
        {
            cutCam.GetComponent<cutsceneHandler>().StartCutscene(startPos);
            for (int i = 0; i < lightning.Length; i++)
            {
                lightning[i].GetComponent<LightningTriggerer>().CreateLightning();
            }
            gameObject.SetActive(false);
            startCam.SetActive(false);
            player.SetActive(true);
        }
    }
}
