using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatueLooking : MonoBehaviour
{
    public GameObject player;

    // Update is called once per frame
    void Update()
    {
        if (!(transform.GetChild(0).GetComponent<MeshRenderer>().isVisible))
            transform.LookAt(player.transform);
    }
}
