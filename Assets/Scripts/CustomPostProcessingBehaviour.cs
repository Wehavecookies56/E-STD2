//Written by Dan Sheshtanov
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class CustomPostProcessingBehaviour : MonoBehaviour
{
    public float autoFocusSpeed;
    public float maxFocusDist;
    public LayerMask autoFocusLayerMask;

    private PostProcessProfile ppp;
    private DepthOfField dof;
    private Vignette vig;

    void Start()
    {
        ppp = GetComponent<PostProcessVolume>().profile;
        ppp.TryGetSettings(out dof);
        ppp.TryGetSettings(out vig);
    }
    
    void Update()
    {
        //fire a ray to get the distance to an object being looked at
        RaycastHit hit;
        Physics.Raycast(transform.position, transform.forward, out hit, 100, autoFocusLayerMask);
        float dist = hit.distance;
        Debug.DrawRay(transform.position, transform.forward * dist);
        //make sure depth of field is active
        dof.active = true;
        
        //if raycast returned a hit and didn't set distance to 0..
        if(dist != 0)
            //..lerp from current DOF to target DOF using autoFocusSpeed
            dof.focusDistance.value = Mathf.MoveTowards(dof.focusDistance.value, dist, autoFocusSpeed * Time.deltaTime);
        else
            //..else, disable DOF effect to allow looking into the distance
            dof.active = false;
    }

    //Starting value = 0.325, range 0 - 1
    internal void SetVignette(float _intensity)
    {
        vig.intensity.value =  _intensity;
    }
}
