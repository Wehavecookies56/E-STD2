﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RitualRoomDoor : MonoBehaviour
{
    public GameObject realDoor;
    public GameObject FakeDoor;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.childCount == 0)
        {
            realDoor.SetActive (true);
            FakeDoor.SetActive(false);
        }
        
    }
}