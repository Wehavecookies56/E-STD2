using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.L))
        {
            GameObject.Find("TriggerableLightning").GetComponent<LightningTriggerer>().CreateLightning();
        }
    }
}
