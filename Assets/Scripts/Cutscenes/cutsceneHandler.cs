//Written by Dan Sheshtanov
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cutsceneHandler : MonoBehaviour
{
    //camera attached to player object, needs to be disabled as the cutscene starts and re-enabled at the end
    public Camera playerCamera;
    //camera used for the cutscene, object that will be moved
    public Camera cutsceneCamera;
    //used to disable and enable the minimap during cutscenes
    public GameObject minimap;
    //tracks wether to run cutscene code or not in Update()
    private bool isInCutsceneMode = false;

    //list of nodes that need to be reached
    private List<cutscenePoint> currentPoints = new List<cutscenePoint>();
    private float currentPointTime = 0f;


    private void Update()
    {
       // if (Input.GetKeyDown(KeyCode.C)) StartCutscene(GameObject.Find("SampleCutsceneNodes")); //TODO test line, REMOVE BEFORE RELEASE
        if (!isInCutsceneMode) return; //if not in cutscene mode, don't run anything to do with cutscenes

        //if final node has been reached
        if(currentPoints.Count < 1)
        {
            //disable cutscene mode
            ToggleMode();
        }

        //add time to current point timer
        currentPointTime += Time.deltaTime;

        //get a reference to the last point in the list
        cutscenePoint currentP = currentPoints[currentPoints.Count - 1];

        //move cutscene camera towards point
        cutsceneCamera.transform.position = Vector3.Lerp(cutsceneCamera.transform.position, currentP.pos, currentP.speed * Time.deltaTime);
        cutsceneCamera.transform.rotation = Quaternion.Lerp(cutsceneCamera.transform.rotation, currentP.transform.rotation, currentP.rotSpeed * Time.deltaTime);

        //if time limit reached, go onto next point
        if(currentPointTime > currentP.time)
        {
            //reset timer and remove last point from list
            currentPointTime = 0;
            currentPoints.RemoveAt(currentPoints.Count - 1);
            //check if reached end
            if (currentPoints.Count < 1)
            {
                //enable the minimap objects
                minimap.SetActive(true);
                ToggleMode();
            }
        }
    }

    public void StartCutscene(GameObject cutsceneParentObj)
    {
        if (cutsceneParentObj.transform.childCount < 1) return; //don't do anything if bad input (specifically empty node list)

        //enable cutscene mode
        ToggleMode();
        //disable the minimap objects
        minimap.SetActive(false);

        //compile the list of nodes from the parent object
        currentPoints.Clear();
        for (int i = cutsceneParentObj.transform.childCount - 1; i > - 1; i--) //parse objects children from end to start
        {
            currentPoints.Add(cutsceneParentObj.transform.GetChild(i).GetComponent<cutscenePoint>());
        }

        //move cutscene camera to appropriate position and rotation to start
        cutsceneCamera.transform.position = currentPoints[currentPoints.Count - 1].transform.position;
        cutsceneCamera.transform.rotation = currentPoints[currentPoints.Count - 1].transform.rotation;
        //init timer
        currentPointTime = 0f;
    }

    private void ToggleMode()
    {
        isInCutsceneMode = !isInCutsceneMode;
        playerCamera.enabled = !playerCamera.enabled;
        cutsceneCamera.enabled = !cutsceneCamera.enabled;
        playerCamera.GetComponent<AudioListener>().enabled = !playerCamera.GetComponent<AudioListener>().enabled;
        cutsceneCamera.GetComponent<AudioListener>().enabled = !cutsceneCamera.GetComponent<AudioListener>().enabled;
    }
}
