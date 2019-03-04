using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerData : MonoBehaviour {
    //Default values are set to the values on the character sheet
    public float Health { get; set; } = 10;
    public float Sanity { get; set; } = 10;
    //Traits are readonly
    public int Strength { get; } = 2;
    public int Agility { get; } = 3;
    public int Intelligence { get; } = 3;
    public int Willpower { get; } = 8;
    public int Perception { get; } = 4;
    public int Charisma { get; } = 6;

    public static playerData INSTANCE = null;

    private void Awake() {
        if (INSTANCE == null) {
            INSTANCE = this;
        } else {
            //Prevent multiple instances from existing at the same time
            Destroy(gameObject);
        }
    }
}
