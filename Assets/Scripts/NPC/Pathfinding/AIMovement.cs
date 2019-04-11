//Script written by Dan Sheshtanov
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMovement : MonoBehaviour
{
    public float speed;
    public float rotationSpeed = 1.0f;

    public GameObject startNode;
    public GameObject endNode;
    public float pathfindingNodeContactPadding;

    private List<GameObject> movementPath = new List<GameObject>();

    public GameObject pathfinderGO;
    private Astar pathfinder;

    //getters
    internal List<GameObject> getMovementPath() { return movementPath; }

    void Start()
    {
        //get reference to the pathfinder object for the desired pathfinding net (specifying a different pathfinding object will result in the use of a different network of nodes, children of that object)
        pathfinder = pathfinderGO.GetComponent<Astar>();

        //if start node and end node predefined in the inspector, calculate a path to go via them
        if(startNode != null && endNode != null)
            movementPath = pathfinder.FindShortestPath(startNode, endNode);

        /*Test output
        Debug.Log("_____________");
        foreach (var item in movementPath)
        {
            Debug.Log(item.name);
        }*/
    }

    //find a path from current position to target via nodes
    internal void GoToLocation(Vector3 target, LayerMask LOSLayer = default)
    {
        startNode = pathfinder.FindNearestNode(transform.position);
        endNode = pathfinder.FindNearestNode(target);

        //if already following a path..
        if(movementPath.Count > 0)
        {
            //..and the path is to the same destination as new target destination..
            if(movementPath[movementPath.Count-1] == endNode && movementPath.Count > 1)
            {
                //..check that the agent even needs to go to the first node or can go straight to second, if so, calculate path from second node instead
                RaycastHit hit;
                Physics.Raycast(transform.position, (movementPath[1].transform.position - transform.position), out hit, LOSLayer);
                if (hit.collider.gameObject == movementPath[1])
                {
                    startNode = movementPath[1];
                }
                //otherwise continue from the same node
                else startNode = movementPath[0];
            }
        }

        movementPath = pathfinder.FindShortestPath(startNode, endNode);
    }

    //clear saved path (and it turn, stop moving)
    internal void ClearMovementPath()
    {
        movementPath.Clear();
    }

    //walk along the current path
    internal void WalkTowardsPath()
    {
        //return if no movement path
        if(movementPath.Count == 0) { return; }

        transform.position = (Vector3.MoveTowards(transform.position, movementPath[0].transform.position, Time.deltaTime * speed));
        //lerp look at the next vector (not the most efficient way to do this but it works)
        //TODO transform.LookAt(movementPath[0].transform.position); OLD SOLUTION
        transform.LookAt(Vector3.Lerp(transform.position + transform.forward, new Vector3(movementPath[0].transform.position.x, transform.position.y, movementPath[0].transform.position.z), rotationSpeed * Time.deltaTime));

        //check if the node has been reached
        if (Vector3.Distance(new Vector3(transform.position.x, 0, transform.position.z), new Vector3(movementPath[0].transform.position.x, 0, movementPath[0].transform.position.z)) < pathfindingNodeContactPadding)
        {
            //remove the node to start moving towards the next one
            movementPath.RemoveAt(0);
        }
    }

    internal void WalkTowardsLocation(Vector3 pos)
    {
        transform.position = (Vector3.MoveTowards(transform.position, pos, Time.deltaTime * speed));
        //lerp look at the next vector (not the most efficient way to do this but it works)
        //TODO transform.LookAt(movementPath[0].transform.position); OLD SOLUTION
        transform.LookAt(Vector3.Lerp(transform.position + transform.forward, new Vector3(pos.x, transform.position.y, pos.z), rotationSpeed * Time.deltaTime));
    }

    internal GameObject FindNearestNodes(Vector3 pos)
    {
        return pathfinder.FindNearestNode(pos);
    }
}
