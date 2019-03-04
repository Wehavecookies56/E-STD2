//Written by Dan Sheshtanov
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShutterMovement : MonoBehaviour
{
    private enum State
    {
        Idle, Stretching, Compressing
    }

    //speed that the curtain can move at, set in the inspector
    public float moveSpeed;

    //scale when curtain fully compressed
    private const float compressedScale = 0.3f;
    //padding for the lerp to stop infinite movement
    private const float lerpPadding = 0.005f;
    //phyisical size of the object in unity units
    private const float objSize = 3.0f;

    //current state of the shutter
    private State state = State.Idle;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q)) ToggleState(); //TODO test input
        //check current state
        switch (state)
        {
            case State.Idle: //dont do anything in idle
                break;

            case State.Stretching:
                //update shutter scale and position
                MoveShutter(1.0f);

                //check if limit has been reached
                if(1.0f - transform.localScale.z < lerpPadding)
                {
                    //force set "end" values to keep accuracy in idle state
                    transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, 1.0f);
                    transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, 0.0f);
                    //update state to allow more interaction
                    state = State.Idle;
                }
                break;

            case State.Compressing:
                //update shutter scale and position
                MoveShutter(compressedScale);

                //check if limit has been reached
                if (Mathf.Abs(compressedScale - transform.localScale.z) < lerpPadding)
                {
                    //force set "end" values to keep accuracy in idle state
                    transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, compressedScale);
                    transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, (1 - transform.localScale.z) * objSize);
                    //update state to allow more interaction
                    state = State.Idle;
                }
                break;
            default:
                break;
        }
    }

    internal void ToggleState()
    {
        if(state == State.Idle)
        {
            if(transform.localScale.z == 1.0f)
            {
                state = State.Compressing;
            }
            else
            {
                state = State.Stretching;
            }
        }
    }

    private void MoveShutter(float target)
    {
        //lerp shutter scale towards target
        transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y,
            Mathf.Lerp(transform.localScale.z, target, moveSpeed * Time.deltaTime));
        //use scale to figure out position offset to create an illusion of one side not moving
        transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y,
            (1 - transform.localScale.z) * objSize);
    }
}
