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
    
    //joint 
    private ConfigurableJoint joint;
    private float defaultBreakForce;
    private float grabHeight = 0.05f;
    private GameObject pickedUpObject;
    private float lerpSpeed = 5f;

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
        Debug.DrawRay(cameraGO.transform.position, cameraGO.transform.TransformDirection(Vector3.forward * pickupDistance), Color.green, 0.1f);

        //if lift object button is pressed
        if (Input.GetButton("Fire1"))
        {
            //add time to button timer
            liftButtonTimer += Time.deltaTime;

            if (liftButtonTimer > liftButtonRequredTime)
            {
                //reset button timer
                liftButtonTimer = 0f;

                //if no object is picked up
                if (pickedUpObject == null)
                {
                    //cast a ray at what the player is looking (within range)
                    RaycastHit hit;
                    if (Physics.Raycast(cameraGO.transform.position, cameraGO.transform.TransformDirection(Vector3.forward), out hit, pickupDistance, layer))
                        //if hit object has a rigidbody..
                        if (hit.rigidbody != null)
                        {
                            pickedUpObject = hit.rigidbody.gameObject;
                            pickedUpObject.GetComponent<Rigidbody>().useGravity = false;
                        }
                }
            }
        }
        if(Input.GetButtonUp("Fire1"))
        { 
            //reset timer if button let go
            liftButtonTimer = 0f;
        }

        if (pickedUpObject != null)
        {
            pickedUpObject.transform.position = Vector3.Lerp(pickedUpObject.transform.position, liftSlot.transform.position, lerpSpeed * Time.deltaTime);
            pickedUpObject.transform.rotation = Quaternion.Lerp(pickedUpObject.transform.rotation, liftSlot.transform.rotation, lerpSpeed * Time.deltaTime);

            if (Input.GetButtonDown("Fire1"))
            {
                //launch object forward and disconnect from joint
                pickedUpObject.GetComponent<Rigidbody>().useGravity = true;
                pickedUpObject.GetComponent<Rigidbody>().AddForce(cameraGO.transform.TransformDirection(Vector3.forward * throwStrength));
                pickedUpObject = null;
            }
        }
    }
}
