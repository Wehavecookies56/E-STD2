using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestOpen : MonoBehaviour
{
    public float anglestop;
    public float speed = 1;
    internal bool opening = false;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       // if (opening)
        {
            if (speed < 0)
            {
                if (transform.eulerAngles.y > anglestop)
                {
                    transform.Rotate(new Vector3(0, Time.deltaTime * speed, 0));
                }
                else
                {
                    transform.eulerAngles = new Vector3(transform.eulerAngles.x, anglestop, transform.eulerAngles.z);
                    opening = false;
                    Destroy(gameObject.GetComponent<ChestOpen>());
                }
            }
            else
            {
                if (transform.eulerAngles.y < anglestop)
                {
                    transform.Rotate(new Vector3(0, Time.deltaTime * speed, 0));
                }
                else
                {
                    transform.eulerAngles = new Vector3(transform.eulerAngles.x, anglestop, transform.eulerAngles.z);
                    opening = false;
                    Destroy(gameObject.GetComponent<ChestOpen>());
                    gameObject.GetComponent<BoxCollider>().isTrigger = false;
                }
            }

        }

    }
}


