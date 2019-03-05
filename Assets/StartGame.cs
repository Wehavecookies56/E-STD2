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
    private bool go = false;
    private float timer = 19;

    private void Start()
    {
        player.transform.parent.GetComponent<PlayerMovement>().enabled = false;
    }

    void Update()
    {
        if(go == false)
        {
            if (Input.anyKeyDown == true)
            {
                cutCam.GetComponent<cutsceneHandler>().StartCutscene(startPos);
                for (int i = 0; i < lightning.Length; i++)
                {
                    lightning[i].GetComponent<LightningTriggerer>().CreateLightning();
                }
                go = true;
                startCam.SetActive(false);
                player.SetActive(true);
                gameObject.transform.GetChild(0).gameObject.SetActive(false);
            }
        }
       

        if(go)
        {
            if (timer <= 0)
            {
                player.transform.parent.GetComponent<PlayerMovement>().enabled = true;
                go = false;
                gameObject.SetActive(false);
            }
            else { timer -= Time.deltaTime; }
        }
    }

    
}
