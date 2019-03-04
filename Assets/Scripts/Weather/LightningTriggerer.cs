using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningTriggerer : MonoBehaviour
{
    public void CreateLightning()
    {
        GetComponent<ParticleSystem>().Emit(1);
    }
}
