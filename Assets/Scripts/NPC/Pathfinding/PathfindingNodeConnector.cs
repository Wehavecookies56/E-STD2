//Written by Dan Sheshtanov
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathfindingNodeConnector : MonoBehaviour
{
    public GameObject PathNetwork;
    public GameObject node1;
    public GameObject node2;

    internal void ConnectPathNodes()
    {
        //connect physical nodes together
        node1.GetComponent<PathNode>().connectedNodes.Add(node2);
        node2.GetComponent<PathNode>().connectedNodes.Add(node1);

        //connect virtual nodes together
        PathNetwork.GetComponent<Astar>().FindNodeWithID(node1.GetComponent<PathNode>().ID).adjacentNodes.Add(
            PathNetwork.GetComponent<Astar>().FindNodeWithID(node2.GetComponent<PathNode>().ID));

        PathNetwork.GetComponent<Astar>().FindNodeWithID(node2.GetComponent<PathNode>().ID).adjacentNodes.Add(
            PathNetwork.GetComponent<Astar>().FindNodeWithID(node1.GetComponent<PathNode>().ID));
    }
}
