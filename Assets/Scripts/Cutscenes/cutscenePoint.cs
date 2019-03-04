//Written by Dan Sheshtanov
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cutscenePoint : MonoBehaviour
{
    //how fast the camera will move for this transition
    public float speed;
    //how fast to rotate the camera
    [Range(0, 1)]
    public float rotSpeed;
    //how long until transition to next point for this transition (seconds)
    public float time;
    //end location of the camera for this transition
    internal Vector3 pos;
    //end rotation of the camera for this transition
    internal Vector3 rot;


    private void Start()
    {
        pos = transform.position;
        rot = transform.rotation.eulerAngles;
    }
}
