//Script Written By Dan Sheshtanov
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightPlayerDetector : MonoBehaviour
{
    private Light l;
    private float lightIntensity;
    private bool isActive = false;
    private float lightLerpSpeed = 1.5f;

    private void Start()
    {
        //save light references and values
        l = GetComponent<Light>();
        lightIntensity = l.intensity;
        l.enabled = false;
    }

    private void Update()
    {
        //if light is active, lerp intensity to it's desired value
        if (isActive)
            l.intensity = Mathf.Lerp(l.intensity, lightIntensity, lightLerpSpeed * Time.deltaTime);
        else
        {
            //lerp intensity towards 0
            l.intensity = Mathf.Lerp(l.intensity, 0f, lightLerpSpeed * Time.deltaTime);
            //if intensity is under 10% of desired intensity..
            if (l.intensity < lightIntensity * 0.01f)
                //..disable the light
                l.enabled = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        //if player in light, keep the light enabled
        l.enabled = true;
        isActive = true;
    }

    private void OnTriggerExit(Collider other)
    {
        //if player leaves light, mark it as disabled
        isActive = false;
    }
    
}
