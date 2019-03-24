using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class touchGymSpirit : MonoBehaviour {
    private void OnTriggerEnter(Collider other) {
        playerData.INSTANCE.Agility++;
        gameObject.SetActive(false);
    }
}
