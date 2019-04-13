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
    public GameObject dot;
    public GameObject minimap;
    public GameObject[] lightning;
    private bool go = false;
    private float timer = 19;
    public GameObject door1;
    public GameObject door2;
    public Objectives objectives;

    private void Start()
    {
        player.transform.parent.GetComponent<PlayerMovement>().enabled = false;
        Cursor.visible = false;
        dot.SetActive(false);
        minimap.SetActive(false); 
    }

    void Update()
    {   

        if (go == false)
        {
            if (Input.anyKeyDown == true)
            {
                player.transform.parent.GetComponent<PlayerMovement>().enabled = true;
                door1.GetComponent<Animator>().enabled = true;
                door2.GetComponent<Animator>().enabled = true;
                text.GetComponent<Animator>().SetTrigger("go");
                for (int i = 0; i < lightning.Length; i++)
                {
                    lightning[i].GetComponent<LightningTriggerer>().CreateLightning();
                }
                go = true;
                startCam.SetActive(false);
                player.SetActive(true);
                cutCam.GetComponent<cutsceneHandler>().StartCutscene(startPos);
            }
        }


        if (go)
        {
            if (!cutCam.GetComponent<cutsceneHandler>().getIsInCutsceneMode())
                timer = 0;

            if (timer <= 0)
            {
                go = false;
                dot.SetActive(true);
                minimap.SetActive(true);
                gameObject.SetActive(false);
                objectives.ActivateObjective(Objectives.ObjectivesEnum.ExploreManor); //add "ExploreManor" objective
            }
            else { timer -= Time.deltaTime; }

        }
    }

    
}
