using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerForMaps : MonoBehaviour
{

    public GameObject MapLower;
    public GameObject MapUpper;
 
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            MapLower.SetActive(false);
            MapUpper.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            MapUpper.SetActive(false);
            MapLower.SetActive(true);
        }
    }
}
