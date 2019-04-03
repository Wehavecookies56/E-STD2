using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookBurnTooltipScript : MonoBehaviour {

    public GameObject inv;

    public GameObject ending;

    public GameObject terrainEnable;

    void Start() {
        
    }

    void Update() {
        GetComponent<tooltipOverride>().display = inv.GetComponent<inventorySelectScript>().isThereA(items.BOOK);
    }

    public void goodEnding() {
        Camera.main.enabled = false;
        ending.SetActive(true);
        terrainEnable.GetComponent<toggleTerrain>().toggle();
    }
}
