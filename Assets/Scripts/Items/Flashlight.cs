using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Flashlight : MonoBehaviour
{
    public GameObject parent;
    public float latitudeOffset;
    public float longitudeOffset;
    public float rotationSpeed;

    //emmisive and non-emissive variants of the glass material for the flashlight
    public Material glassOff;
    public Material glassOn;

    private bool isOn = true;

    //material arrays to change between emmisive and non-emissive materials when the light gets toggled
    private Material[] offMatsLOD0and2 = new Material[3];
    private Material[] offMatsLOD1 = new Material[3];
    private Material[] onMatsLOD0and2 = new Material[3];
    private Material[] onMatsLOD1 = new Material[3];

    //reference to the extra light child
    private Light innerLight;

    void Start()
    {
        //get a reference to the inner light
        innerLight = transform.GetChild(3).GetComponent<Light>();

        //get standard flashlight material from the object
        Material flashlightMat = transform.GetChild(0).GetComponent<MeshRenderer>().materials[2];

        //populate each materials array accordingly
        offMatsLOD0and2[0] = glassOff; offMatsLOD0and2[1] = glassOff; offMatsLOD0and2[2] = flashlightMat;
        offMatsLOD1[0] = flashlightMat; offMatsLOD1[1] = glassOff; offMatsLOD1[2] = glassOff;
        onMatsLOD0and2[0] = glassOff; onMatsLOD0and2[1] = glassOn; onMatsLOD0and2[2] = flashlightMat;
        onMatsLOD1[0] = flashlightMat; onMatsLOD1[1] = glassOff; onMatsLOD1[2] = glassOn;
    }
    
    void Update()
    {
        //TODO test input, need to be moved to player scripts
        if(Input.GetButtonDown("Fire2"))
        {
            ToggleLight();
        }

        if (parent != null)
        {
            //move to the parents position
            transform.position = parent.transform.position;

            //lerp rotate towards the parents orientation
            transform.rotation = Quaternion.Euler(
                Mathf.LerpAngle(transform.rotation.eulerAngles.x, parent.transform.rotation.eulerAngles.x - latitudeOffset, rotationSpeed * Time.deltaTime),
                Mathf.LerpAngle(transform.rotation.eulerAngles.y, parent.transform.rotation.eulerAngles.y - longitudeOffset, rotationSpeed * Time.deltaTime),
                0);
        }
    }

    internal void ToggleLight()
    {
        isOn = !isOn;

        if(isOn)
        {
            //activate lights
            GetComponent<Light>().enabled = true;
            innerLight.enabled = true;
            //update materials to emmisive variants
            transform.GetChild(0).GetComponent<MeshRenderer>().materials = onMatsLOD0and2;
            transform.GetChild(1).GetComponent<MeshRenderer>().materials = onMatsLOD1;
            transform.GetChild(2).GetComponent<MeshRenderer>().materials = onMatsLOD0and2;
        }
        else
        {
            //deactivate lights
            GetComponent<Light>().enabled = false;
            innerLight.enabled = false;
            //change update materials to non-emissive variants
            transform.GetChild(0).GetComponent<MeshRenderer>().materials = offMatsLOD0and2;
            transform.GetChild(1).GetComponent<MeshRenderer>().materials = offMatsLOD1;
            transform.GetChild(2).GetComponent<MeshRenderer>().materials = offMatsLOD0and2;
        }
    }
}
