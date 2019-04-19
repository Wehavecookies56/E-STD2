//Written by Dan Sheshtanov
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cutsceneHandler : MonoBehaviour
{
    //camera attached to player object, needs to be disabled as the cutscene starts and re-enabled at the end
    public Camera playerCamera;
    private PlayerMovement playerInput;
    //camera used for the cutscene, object that will be moved
    public Camera cutsceneCamera;
    //used to disable and enable the minimap during cutscenes
    public RawImage minimap;
    public float colourChangeSpeed;
    //flashlight handling
    public GameObject flashlight;
    //tracks wether to run cutscene code or not in Update()
    private bool isInCutsceneMode = false;

    //list of nodes that need to be reached
    private List<cutscenePoint> currentPoints = new List<cutscenePoint>();
    private float currentPointTime = 0f;

    internal bool getIsInCutsceneMode() { return isInCutsceneMode; }

    private void Start()
    {
        playerInput = playerCamera.GetComponentInParent<PlayerMovement>();
    }

    private void Update()
    {
        if (!isInCutsceneMode) //if not in cutscene mode..
            if (minimap.color.a == 1.0f) return; //..and minimap full opacity, don't run anything to do with cutscenes
            else //if minimap not fully opaque..
            {
                //..increase opacity by colourChangeSpeed over time
                minimap.color = new Color(
                minimap.color.r,
                minimap.color.g,
                minimap.color.b,
                Mathf.Clamp01(minimap.color.a + colourChangeSpeed * Time.deltaTime));
                return;
            }

        //if minimap is visible..
        if (minimap.color.a != 0.0f)
        {
            //..reduce opacity by colourChangeSpeed over time
            minimap.color = new Color(
            minimap.color.r,
            minimap.color.g,
            minimap.color.b,
            Mathf.Clamp01(minimap.color.a - colourChangeSpeed * Time.deltaTime));
        }

        //if final node has been reached
        if(currentPoints.Count < 1)
        {
            //disable cutscene mode
            ToggleMode();
            return;
        }

        //add time to current point timer
        currentPointTime += Time.deltaTime;

        //get a reference to the last point in the list
        cutscenePoint currentP = currentPoints[currentPoints.Count - 1];

        //TODO DEBUG RAY DRAWING to the next node
        Debug.DrawRay(cutsceneCamera.transform.position, currentP.pos - cutsceneCamera.transform.position);

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
                //enable the minimap objects |REPLACED WITH COLOUR OVER TIME METHOD|
                //minimap.SetActive(true);
                ToggleMode();
            }
        }
    }

    public void StartCutscene(GameObject cutsceneParentObj)
    {
        if (cutsceneParentObj.transform.childCount < 1) return; //don't do anything if bad input (specifically empty node list)

        //enable cutscene mode
        ToggleMode();
        //disable the minimap objects |REPLACED WITH COLOUR OVER TIME METHOD|
        //minimap.SetActive(false);

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
        playerInput.enabled = !playerInput.enabled;
        cutsceneCamera.enabled = !cutsceneCamera.enabled;
        playerCamera.GetComponent<AudioListener>().enabled = !playerCamera.GetComponent<AudioListener>().enabled;
        cutsceneCamera.GetComponent<AudioListener>().enabled = !cutsceneCamera.GetComponent<AudioListener>().enabled;
        HandleFlashlight();
        playerCamera.transform.parent.GetChild(3/*footstep sound*/).GetComponent<AudioSource>().volume = 0f; //prevents footstep sounds in cutscenes
    }

    private void HandleFlashlight()
    {
        Flashlight test;
        if (flashlight.GetComponent<Flashlight>().parent != null)
            test = flashlight.GetComponent<Flashlight>();

        if (flashlight.GetComponent<Flashlight>().parent == null)
            return;

        //if flashlight is following player or cutscene cam
        //                                                                              |flashlight|          |script| |object to follow|      |player camera|   |GameObject|
        if (flashlight.GetComponent<Flashlight>().parent == cutsceneCamera.gameObject || flashlight.GetComponent<Flashlight>().parent.gameObject.transform.parent.gameObject == playerCamera.gameObject)
        {
            if (isInCutsceneMode) //if in cutscene mode..
            {
                flashlight.GetComponent<Flashlight>().parent = cutsceneCamera.gameObject; //..move light to follow cutcam
            }
            else
            {
                flashlight.GetComponent<Flashlight>().parent = playerCamera.gameObject.transform.GetChild(1).gameObject; //..else make it follow player
            }
        }
    }

    internal void SkipCutscene()
    {
        currentPoints.Clear();
    }
}
