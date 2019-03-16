//Script written by Dan Sheshtanov
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAI : MonoBehaviour
{
    public GameObject DEBUGPOSOBJ;

    public float speed;
    public float rotationSpeed = 1.0f;

    public GameObject startNode;
    public GameObject endNode;
    public float pathfindingNodeContactPadding;

    private List<GameObject> movementPath = new List<GameObject>();

    private Rigidbody rb;

    public GameObject pathfinderGO;
    private Astar pathfinder;

    Animator anim;
    
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetFloat("movespeed", speed);
        //get reference to it's own rigidbody
        rb = GetComponent<Rigidbody>();
        //get reference to the pathfinder object for the desired pathfinding net (specifying a different pathfinding object will result in the use of a different network of nodes, children of that object)
        pathfinder = pathfinderGO.GetComponent<Astar>();

        //if start node and end node predefined in the inspector, calculate a path to go via them
        if(startNode != null && endNode != null)
            movementPath = pathfinder.FindShortestPath(startNode, endNode);

        //print movement path
        //Debug.Log("_____________");
        //foreach (var item in movementPath)
        //{
        //    Debug.Log(item.name);
        //}
    }
    
    void Update()
    {
        //if there is a path to go to
        if (movementPath.Count > 0)
        {
            //move towards the first node in the path
            rb.MovePosition(Vector3.MoveTowards(rb.position, movementPath[0].transform.position, Time.deltaTime * speed));
            //lerp look at the next vector (not the most efficient way to do this but it works)
            //TODO transform.LookAt(movementPath[0].transform.position); OLD SOLUTION
            transform.LookAt(Vector3.Lerp( transform.position + transform.forward, new Vector3(movementPath[0].transform.position.x, transform.position.y, movementPath[0].transform.position.z), rotationSpeed * Time.deltaTime));

            //check if the node has been reached
            if (Vector3.Distance(new Vector3(transform.position.x, 0, transform.position.z), new Vector3(movementPath[0].transform.position.x, 0, movementPath[0].transform.position.z)) < pathfindingNodeContactPadding)
            {
                //remove the node to start moving towards the next one
                movementPath.RemoveAt(0);
            }
        }
        else //TODO test - force to go to a new node
        {
            GoToLocation(new Vector3(Random.Range(-7f, 6f), 0, Random.Range(-9f, 7f)));
            //debug option to place an object over the endNode
            if (DEBUGPOSOBJ != null)
            {
                DEBUGPOSOBJ.transform.position = endNode.transform.position;
                DEBUGPOSOBJ.transform.Translate(0, 3f, 0);
            }
        }
    }

    //find a path from current position to target via nodes
    internal void GoToLocation(Vector3 target)
    {
        startNode = pathfinder.FindNearestNode(transform.position);
        endNode = pathfinder.FindNearestNode(target);
        movementPath = pathfinder.FindShortestPath(startNode, endNode);
    }

    //clear saved path (and it turn, stop moving)
    internal void ClearMovementPath()
    {
        movementPath.Clear();
    }
}
