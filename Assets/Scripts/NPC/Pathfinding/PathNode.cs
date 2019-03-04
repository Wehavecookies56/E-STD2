//Script written by Dan Sheshtanov
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathNode : MonoBehaviour
{
    private static int IDCounter = 0; //number for giving a node a numeric ID

    internal int ID = -1; //numeric ID of this node
    public List<GameObject> connectedNodes = new List<GameObject>();
    
    void Awake()
    {
        IDCounter++;
        ID = IDCounter;
    }
}
