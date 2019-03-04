using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItemPickUp : MonoBehaviour
{
    private inventoryManager inventory;
    public GameObject inventoryItemPartner;

    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<inventoryManager>();
    }


    public void pickUpItem()
    {
        for (int i = 0; i < inventory.slots.Length; i++)
        {
            if (inventory.isFull[i] == false)
            {
                //slot is empty item can be added
                inventory.isFull[i] = true;
                Instantiate(inventoryItemPartner, inventory.slots[i].transform, false);
                Destroy(gameObject);
                //just for the candle
                if(gameObject.name == "blackCandle")
                {
                   //TODO play screems 
                }
                break;
            }
        }
    }
}
