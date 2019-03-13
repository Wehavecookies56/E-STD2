using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorRotate : MonoBehaviour
{
    public float anglestop;
    public float speed = 1;
    internal bool opening = false;
    public bool needskey = false;
    public bool needsAxe = false;

    // Update is called once per frame
    void FixedUpdate()
    {

       if (opening)
        {
            if (speed < 0)
            {
                if (transform.localEulerAngles.y > anglestop)
                {
                    transform.Rotate(new Vector3(0, Time.deltaTime * speed, 0));
                }
                else
                {
                    transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, anglestop, transform.localEulerAngles.z);
                    opening = false;
                    Destroy(gameObject.GetComponent<DoorRotate>());
                }
            }
            else
            {
                if (transform.localEulerAngles.y < anglestop)
                {
                    transform.Rotate(new Vector3(0, Time.deltaTime * speed, 0));
                }
                else
                {
                    transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, anglestop, transform.localEulerAngles.z);
                    opening = false;
                    Destroy(gameObject.GetComponent<DoorRotate>());
                    gameObject.GetComponent<BoxCollider>().isTrigger = false;
                }
            }

        }

    }

   

}
       

        
