using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mimicScript : MonoBehaviour {

    public GameObject portal;

    void Start() {
        
    }

    public void bite() {
        GetComponent<Animator>().SetTrigger("bite");
        GetComponent<Rigidbody>().velocity = Vector3.up;
        playerData.INSTANCE.Health -= 2;
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("mimic")) {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }

    public void openPortal() {
        GetComponent<Rigidbody>().useGravity = true;
        GetComponent<BoxCollider>().isTrigger = true;
        gameObject.layer = 1 << 0;
        portal.SetActive(true);
    }

    private IEnumerator disappear() {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }
}
