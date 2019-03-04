//Script written by Dan Sheshtanov
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Astar : MonoBehaviour
{
    //class for holding data for each node
    internal class Node
    {
        internal Node(GameObject _physicalNode) //constructor for Node
        {
            physicalNode = _physicalNode;
            ID = _physicalNode.GetComponent<PathNode>().ID;
        }

        //one-time write variables
        internal int ID = -1; //numeric ID of this node, matches ID of physical node
        internal GameObject physicalNode = null; //the linked node in the game world
        internal List<Node> adjacentNodes = new List<Node>(); //list of attached nodes
        //multiple writes variables
        internal Node parentNode = null; //the node that was crossed to get to this node
        internal float g; //exact cost from the starting point to this node
        internal float h; //estimated cost from this node to the end node
        internal float f; //g + h
    }


    //an array to hold all pathfinding nodes in the scene
    private List<GameObject> physicalNodes = new List<GameObject>();
    private List<Node> nodes = new List<Node>();

    void Awake()
    {
        //populate the physicalNodes array with all found node GameObjects in the scene
        for (int childI = 0; childI < transform.childCount; childI++)
        {
            if (transform.GetChild(childI).tag == "PathfindingNode")
                physicalNodes.Add(transform.GetChild(childI).gameObject);
        }

        Debug.Log("Found " + physicalNodes.Count + " pathfinding nodes.");

        //create "virtual" nodes for all physicalNodes
        InitializeNodes();
        Debug.Log("Created " + nodes.Count + " virtual nodes.");

        /*debugging information, lists all pathfinding nodes and their connections
        foreach (Node item in nodes)
        {
            Debug.Log("___________________________");
            Debug.Log(item.physicalNode.name + ", ID: " + item.ID + ", has " + item.adjacentNodes.Count + " adjacent nodes:");
            foreach (Node node in item.adjacentNodes)
            {
                Debug.Log("     -" + node.physicalNode.name);
            }
        }
        */
    }

    private void InitializeNodes()
    {
        //create a node and add it to the list
        foreach (GameObject item in physicalNodes)
        {
            nodes.Add(new Node(item));
        }

        //add adjacent nodes to all nodes using ID matching across physical and virtual nodes
        foreach (Node node in nodes)
        {
            foreach (GameObject nodeToAttach in node.physicalNode.GetComponent<PathNode>().connectedNodes)
            {
                node.adjacentNodes.Add(FindNodeWithID(nodeToAttach.GetComponent<PathNode>().ID));
            }
        }
    }

    private Node FindNodeWithID(int id)
    {
        foreach (Node n in nodes) //parse all nodes
        {
            if (n.ID == id) //compare IDs 
                return n; //return matching node
        }
        Debug.Log("Node with ID " + id + " not found");
        return null;
    }

    //A* algorithm for finding the path between 2 pathfinding nodes
    internal List<GameObject> FindShortestPath(GameObject startGO, GameObject endGO)
    {
        #region setup
        //reset node data for new search
        foreach (Node node in nodes)
        {
            node.parentNode = null;
            node.g = 0;
            node.h = 0;
            node.f = 0;
        }

        //create a list to hold the path
        List<GameObject> path = new List<GameObject>();

        //reference to the current node
        Node n = null;
        //list to hold "candidate" nodes that may be checked for pathing
        List<Node> openList = new List<Node>();
        //list to hold closed nodes that have been checked and crossed
        List<Node> closedList = new List<Node>();

        //create nodes for start and finish
        Node startNode = FindNodeWithID(startGO.GetComponent<PathNode>().ID);
        Node endNode = FindNodeWithID(endGO.GetComponent<PathNode>().ID);

        //set current node to first node
        n = startNode;
        openList.Add(n);
        #endregion

        #region algorithm
        //keep searching until current node matches end node
        while (n != endNode)
        {
            //add current node to list of visited nodes (closeList) and remove it from frontier (openList)
            closedList.Add(n);
            openList.Remove(n);

            //check if any nodes on openList can be reached quicker from this node than their current parent node, if yes, update their parent and recalculate values
            for (int i = 0; i < openList.Count; i++)
            {
                if (n.g + Vector3.Distance(n.physicalNode.transform.position, n.parentNode.physicalNode.transform.position) < openList[i].g && openList[i].adjacentNodes.Contains(n)) //only change parent if it's adjacent to current node
                {
                    openList[i].parentNode = n;
                    openList[i] = CalculateValues(openList[i], endNode); //not most efficient solution as h value is recalculated despite staying the same, unnecesary Vector3.Distance() calculation!
                }
            }

            //parse all nodes adjacent to current node that are not already on the openList and closedList
            for (int i = 0; i < n.adjacentNodes.Count; i++)
            {
                if (!openList.Contains(n.adjacentNodes[i]) && !closedList.Contains(n.adjacentNodes[i]))
                {
                    //calculate and set data for "currently being checked" node
                    n.adjacentNodes[i].parentNode = n;
                    openList.Add(n.adjacentNodes[i]);
                    n.adjacentNodes[i] = CalculateValues(n.adjacentNodes[i], endNode);
                    //check if end node found
                    if (n.adjacentNodes[i] == endNode)
                    {
                        //add end node to the closed list
                        closedList.Add(n.adjacentNodes[i]);
                        //set current node to end node to force leave the loop
                        n = endNode;
                        break;
                        //N.B! this can cause the final "edge" of the traversal not be optimised, only an issue if the end node is alone far away from the rest of the nodes, this has a possibility of leaving the algorithm too early and using a poor "edge" for the penultimate and final nodes.
                    }
                }
            }

            //force leave the search if end was found
            if (n == endNode)
                break;

            //find the cheapest f-cost node in openNodes
            Node lowestCostNode = openList[0];
            foreach (Node node in openList)
            {
                //if "currently being checked" node is cheaper than "current cheapest" node, set "current cheapest" node to "currently being checked" one
                if (node.f < lowestCostNode.f)
                    lowestCostNode = node;
            }
            //set cheapest f-cost node to current node
            n = lowestCostNode;
        }
        #endregion

        #region resolution
        //recursive function to compile a path of node GameObjects to be followed by AI
        path = AddNodeToPath(n, path);
        //reverse order of the path as it's added to list back to front
        path.Reverse();
        #endregion

        return path;
    }

    private Node CalculateValues(Node n, Node end)
    {
        n.g = n.parentNode.g + Vector3.Distance(n.physicalNode.transform.position, n.parentNode.physicalNode.transform.position);
        n.h = Vector3.Distance(n.physicalNode.transform.position, end.physicalNode.transform.position);
        n.f = n.g + n.h;
        return n;
    }

    private List<GameObject> AddNodeToPath(Node n, List<GameObject> path)
    {
        path.Add(n.physicalNode); //add node to path
        if (n.parentNode != null) //if this node doesn't have a parent it must be the start node
            AddNodeToPath(n.parentNode, path); //if it does have a parent, recursively add that node to the path
        return path; //back out of all calls and return the full path
    }

    internal GameObject FindNearestNode(Vector3 pos)
    {
        //assign first node in list as the current shortest path
        int nodeIndex = 0;
        float shortestDistance = Vector3.Distance(pos, nodes[0].physicalNode.transform.position);

        //iterate all nodes
        for (int n = 1; n < nodes.Count; n++)
        {
            float tempDist;
            //if current node is closer than current closer node, overwrite closest node with current nodes data
            if ((tempDist = Vector3.Distance(pos, nodes[n].physicalNode.transform.position)) < shortestDistance)
            {
                nodeIndex = n;
                shortestDistance = tempDist;
            }
        }

        //return closest node
        return nodes[nodeIndex].physicalNode;
    }
}
