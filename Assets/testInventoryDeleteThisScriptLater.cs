using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testInventoryDeleteThisScriptLater : MonoBehaviour
{
    public GameObject inventory;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            inventory.GetComponent<inventorySelectScript>().dropAxe();
            playerData.INSTANCE.Health -= 2;
            gameObject.SetActive(false);
        }
    }
}
