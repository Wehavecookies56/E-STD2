using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onAxeClick : MonoBehaviour
{
    public void onClick()
    {
        GameObject.FindGameObjectWithTag("description").GetComponent<descriptionManager>().activateDescription(descriptionManager.descriptionType.AXE);
    }
}
