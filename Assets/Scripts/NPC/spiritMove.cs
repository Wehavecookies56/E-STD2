using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spiritMove : MonoBehaviour {

    public float speed;
    public float time;

    float timeTaken;

    private void OnEnable() {
        timeTaken = 0;
    }

    private void Update() {
        timeTaken += Time.deltaTime;
        transform.position += Vector3.forward * Time.deltaTime * speed;
        if (timeTaken >= time) {
            gameObject.SetActive(false);
        }
    }
}
