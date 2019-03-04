using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerActive : MonoBehaviour
{
    public GameObject fakeItem;
    public GameObject realItem;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            fakeItem.SetActive(false);
            realItem.SetActive(true);
        }
    }
}
