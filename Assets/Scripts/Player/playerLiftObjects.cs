//Written by Dan Sheshtanov
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerLiftObjects : MonoBehaviour
{
    public GameObject cameraGO;
    public GameObject liftSlot;
    public LayerMask layer;
    public float pickupDistance;
    public float throwStrength;
    
    private ConfigurableJoint joint;
    private float defaultBreakForce;
    private float grabHeight = 0.05f;

    //input vars
    private const float liftButtonRequredTime = 0.8f;
    private float liftButtonTimer = 0f;

    private void Start()
    {
        joint = liftSlot.GetComponent<ConfigurableJoint>();
        defaultBreakForce = joint.breakForce;
    }

    void Update()
    {
        //Debug.DrawRay(cameraGO.transform.position, cameraGO.transform.TransformDirection(Vector3.forward * pickupDistance), Color.green, 0.1f);

        //if lift object button is pressed
        if (Input.GetButton("Fire1"))
        {
            //add time to button timer
            liftButtonTimer += Time.deltaTime;

            if (liftButtonTimer > liftButtonRequredTime)
            {
                //reset button timer
                liftButtonTimer = 0f;

                //check if a joint exists
                if (joint == null)
                {
                    //if no joint, add a new one and update reference and set properties
                    liftSlot.AddComponent<ConfigurableJoint>();
                    joint = liftSlot.GetComponent<ConfigurableJoint>();
                    joint.xMotion = ConfigurableJointMotion.Limited;
                    joint.yMotion = ConfigurableJointMotion.Limited;
                    joint.zMotion = ConfigurableJointMotion.Limited;
                    joint.breakForce = defaultBreakForce;
                }

                //if no joint currently attached
                if (joint.connectedBody == null)
                {
                    //cast a ray at what the player is looking (within range)
                    RaycastHit[] hits;
                    hits = Physics.RaycastAll(cameraGO.transform.position, cameraGO.transform.TransformDirection(Vector3.forward), pickupDistance, layer);

                    //check all hit colliders
                    foreach (RaycastHit hit in hits)
                    {
                        //if hit object has a rigidbody..
                        if (hit.rigidbody != null)
                        {
                            //..move to appropriate location..
                            hit.rigidbody.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                            hit.rigidbody.transform.position = new Vector3(liftSlot.transform.position.x, liftSlot.transform.position.y - grabHeight, liftSlot.transform.position.z);
                            //..and attach to the joint
                            joint.connectedBody = hit.rigidbody;
                            //only do this to the first object
                            break;
                        }
                    }
                }
                else //if already holding an object
                {
                    //"let go" of object
                    joint.connectedBody = null;
                }
            }
        }
        if(Input.GetButtonUp("Fire1"))
        { 
            //reset timer if button let go
            liftButtonTimer = 0f;
        }

        //if joint exists and has a connected body
        if(joint != null && joint.connectedBody != null)
        {
            //if throw button pressed
            if(Input.GetButtonDown("Fire1"))
            {
                //launch object forward and disconnect from joint
                joint.connectedBody.gameObject.GetComponent<Rigidbody>().AddForce(cameraGO.transform.TransformDirection(Vector3.forward * throwStrength));
                joint.connectedBody = null;
            }
        }
    }
}
