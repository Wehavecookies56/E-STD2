using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateSimple : MonoBehaviour
{
    public Vector3 rot;

    private void Update()
    {
        transform.Rotate(rot);
    }
}
