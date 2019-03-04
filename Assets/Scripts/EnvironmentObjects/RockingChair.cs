//Written By Dan Sheshtanov
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockingChair : MonoBehaviour
{
    public float maxRock;
    public float rockSpeed;
    private bool isRockingForward = true;
    private float currentRotation = 0;
    
    
    void Update()
    {
        if(isRockingForward)
        {
            currentRotation = currentRotation + rockSpeed * (maxRock - Mathf.Abs(currentRotation)) * Time.deltaTime;
            currentRotation = Mathf.Clamp(currentRotation, -maxRock, maxRock);
            if (currentRotation > maxRock * 0.9f)
                isRockingForward = false;
        }
        else
        {
            currentRotation = currentRotation - rockSpeed * (maxRock - Mathf.Abs(currentRotation)) * Time.deltaTime;
            currentRotation = Mathf.Clamp(currentRotation, -maxRock, maxRock);
            if (currentRotation < -maxRock * 0.9f)
                isRockingForward = true;
        }

        transform.rotation = Quaternion.Euler(currentRotation, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
    }
}
