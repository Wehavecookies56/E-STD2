using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerData : MonoBehaviour {
    //Default values are set to the values on the character sheet
    private float health = 10;
    public float Health {
        get
        {
            return health;
        }

        set
        {
            health = value;
            soundManagerScript.audioPlayer.dialogPlay(soundManagerScript.Priest.HURT, GameObject.FindGameObjectWithTag("Player").transform);
               
        }
    }
    public float Sanity { get; set; } = 10;
 
    //Traits
    public int Strength { get; set; } = 2;
    public int Agility { get; set; } = 3;
    public int Intelligence { get; set; } = 3;
    public int Willpower { get; set; } = 8;
    public int Perception { get; set; } = 4;
    public int Charisma { get; set; } = 6;

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
