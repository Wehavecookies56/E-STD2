//Written By Dan Sheshtanov
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLightColliderDetectorFollower : MonoBehaviour
{
    public float heightOffset;
    public GameObject player;
    
    void Update()
    {
        transform.position = player.transform.position + new Vector3(0f, heightOffset, 0f);
    }
}
