//Written By Dan Sheshtanov
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class AStarNetBuilder : MonoBehaviour
{
    private int connectionCounter = 0;

    internal void BuildNetwork()
    {
        //clear all connected nodes
        for (int i = 0; i < transform.childCount; i++)
        {
            //TODO FAILSAFE TO DELETE ALL SPHERE COLLIDERS FROM NODES IN CASE OF OUTBREAK!!!
            /*while (transform.GetChild(i).GetComponent<SphereCollider>() != null)
            {
                DestroyImmediate(transform.GetChild(i).GetComponent<SphereCollider>());
            }*/

            connectionCounter = 0;
            //clear current network
            transform.GetChild(i).GetComponent<PathNode>().connectedNodes.Clear();
            //add a temporary sphere collider to every node
            transform.GetChild(i).gameObject.AddComponent<SphereCollider>();
        }
        
        for (int nI = 0; nI < transform.childCount; nI++)
        {
            var TEMPTHING = transform.GetChild(nI).GetComponent<PathNode>().connectedNodes;
            //add temporary colliders to the outer child

            for (int nJ = nI + 1; nJ < transform.childCount; nJ++)
            {
                var TEMPTHING2 = transform.GetChild(nJ).GetComponent<PathNode>().connectedNodes;

                //cast a ray to the other child
                RaycastHit hit;
                Physics.Raycast(transform.GetChild(nI).transform.position,  transform.GetChild(nJ).transform.position - transform.GetChild(nI).transform.position, out hit);
                Debug.DrawRay(transform.GetChild(nI).transform.position, transform.GetChild(nJ).transform.position - transform.GetChild(nI).transform.position, Color.blue, 4f);

                //check if other child was hit
                if (hit.collider != null)
                {
                    if (hit.collider.gameObject == transform.GetChild(nJ).gameObject)
                    {
                        transform.GetChild(nI).GetComponent<PathNode>().connectedNodes.Add(transform.GetChild(nJ).gameObject);
                        transform.GetChild(nJ).GetComponent<PathNode>().connectedNodes.Add(transform.GetChild(nI).gameObject);
                        connectionCounter++;
                    }
                }
            }
            
        }
        Debug.Log("Made " + connectionCounter + " two-way connections.");

        //remove all temporary colliders
        for (int i = 0; i < transform.childCount; i++)
        {
            DestroyImmediate(transform.GetChild(i).GetComponent<SphereCollider>());
        }
    }
}
