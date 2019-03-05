using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onCrystalBallClick : MonoBehaviour
{
    public void onClick()
    {
        GameObject.FindGameObjectWithTag("description").GetComponent<descriptionManager>().activateDescription(descriptionManager.descriptionType.CRYSTALBALL);
    }
}
