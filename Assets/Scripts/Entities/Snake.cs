//written by Dan Sheshtanov
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Snake : MonoBehaviour
{
    internal enum States //all the states the snake can be in
    {
        WAITING, //before player triggers event
        ENTERING, //going to the point before the chase
        CHASING, //chasing the player
        LEAVING, //going to a point before going to the final point
        EXITING //final point where the gameobject will be disabled
    }

    public float movementSpeed;
    public float rotationSpeed;
    public GameObject player;
    public GameObject snakeEntrance; //where the snake goes before chasing the player
    public GameObject snakeExit; //where the snake goes after biting the player
    public GameObject snakeExit2; //where the snake goes to be disabled

    internal States state = States.WAITING;

    private const int DAMAGE = 2;
    private const float distancePadding = 0.25f;

    // Update is called once per frame
    void Update()
    {
        Vector3 dir;
        Quaternion lookRot;
        switch (state)
        {
            case States.WAITING:
                break;
            case States.ENTERING:
                //move
                transform.position = Vector3.MoveTowards(transform.position, snakeEntrance.transform.position, movementSpeed * Time.deltaTime);
                //look
                dir = snakeEntrance.transform.position - transform.position;
                lookRot = Quaternion.LookRotation(dir);
                lookRot.x = 0; lookRot.z = 0;
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(lookRot.eulerAngles.x, lookRot.eulerAngles.y - 90.0f, lookRot.z), rotationSpeed * Time.deltaTime);
                //check
                if(Vector3.Distance(transform.position, snakeEntrance.transform.position) < distancePadding)
                {
                    state = States.CHASING;
                }
                break;
            case States.CHASING:
                //move
                transform.position = Vector3.MoveTowards(transform.position, player.transform.position, movementSpeed * Time.deltaTime);
                //look
                dir = player.transform.position - transform.position;
                lookRot = Quaternion.LookRotation(dir);
                lookRot.x = 0; lookRot.z = 0;
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(lookRot.eulerAngles.x, lookRot.eulerAngles.y - 90.0f, lookRot.z), rotationSpeed * Time.deltaTime);
                break;
            case States.LEAVING:
                //move
                transform.position = Vector3.MoveTowards(transform.position, snakeExit.transform.position, movementSpeed * Time.deltaTime);
                //look
                dir = snakeExit.transform.position - transform.position;
                lookRot = Quaternion.LookRotation(dir);
                lookRot.x = 0; lookRot.z = 0;
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(lookRot.eulerAngles.x, lookRot.eulerAngles.y - 90.0f, lookRot.z), rotationSpeed * 2 * Time.deltaTime); //multiplied by 2 for a faster effect
                //check
                if (Vector3.Distance(transform.position, snakeExit.transform.position) < distancePadding)
                {
                    state = States.EXITING;
                }
                break;
            case States.EXITING:
                //move
                transform.position = Vector3.MoveTowards(transform.position, snakeExit2.transform.position, (movementSpeed / 2) * Time.deltaTime); //half the movement speed for slower effect
                //look
                dir = snakeExit2.transform.position - transform.position;
                lookRot = Quaternion.LookRotation(dir);
                lookRot.x = 0; lookRot.z = 0;
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(lookRot.eulerAngles.x, lookRot.eulerAngles.y - 90.0f, lookRot.z), rotationSpeed * Time.deltaTime);
                //check
                if (Vector3.Distance(transform.position, snakeExit2.transform.position) < distancePadding)
                {
                    gameObject.SetActive(false);
                }
                break;
            default:
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //if collides with player whilst chasing player
        if(other.gameObject == player && state == States.CHASING)
        {
            playerData.INSTANCE.Health -= DAMAGE;
            state = States.LEAVING;
        }
    }
}
