using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestOpen : MonoBehaviour
{
    public float anglestop;
    public float speed = 1;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (speed < 0)
        {
            if (transform.eulerAngles.x > anglestop)
            {
                transform.Rotate(new Vector3(Time.deltaTime * speed, 0, 0));
            }
            else
            {
                transform.eulerAngles = new Vector3(anglestop, transform.eulerAngles.y, transform.eulerAngles.z);
            }
        }
        else
        {
            if (transform.eulerAngles.x < anglestop)
            {
                transform.Rotate(new Vector3(Time.deltaTime * speed, 0, 0));
            }
            else
            {
                transform.eulerAngles = new Vector3(anglestop, transform.eulerAngles.y, transform.eulerAngles.z);
            }
        }
    }
}


