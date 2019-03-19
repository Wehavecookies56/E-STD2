using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basementMiniMapTrigger : MonoBehaviour
{
   
    public GameObject MapLower;
    public GameObject MapBasement;
    public GameObject playerIcon;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            MapLower.SetActive(false);
            playerIcon.SetActive(false);
            MapBasement.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            MapBasement.SetActive(false);
            MapLower.SetActive(true);
            playerIcon.SetActive(true);
        }
    }
}
