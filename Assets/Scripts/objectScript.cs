using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectScript : MonoBehaviour {

    public objectScriptable data;

    void Start() {
        gameObject.name = data.ObjectName;
    }

    void Update() {
        
    }
}
