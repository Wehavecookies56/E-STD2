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



        ////DEBUGGING VERSION
        //Astar testRef = PathNetwork.GetComponent<Astar>();
        //int ID1 = node1.GetComponent<PathNode>().ID;
        //int ID2 = node2.GetComponent<PathNode>().ID;
        //Astar.Node testNode1 = PathNetwork.GetComponent<Astar>().FindNodeWithID(ID1);
        //Astar.Node testNode2 = PathNetwork.GetComponent<Astar>().FindNodeWithID(ID2);
        //testNode1.adjacentNodes.Add(testNode2);
        //testNode2.adjacentNodes.Add(testNode1);
        ////DEBUGGING VERSION END
    }
}
