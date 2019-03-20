using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatueLooking : MonoBehaviour
{
    public GameObject player;

    // Update is called once per frame
    void Update()
    {
        //if inverse of player (or any other active camera) is looking at statue
        if (!(transform.GetChild(0).GetComponent<MeshRenderer>().isVisible))
            //look at player but ignore y
            transform.LookAt(new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z));
    }
}
