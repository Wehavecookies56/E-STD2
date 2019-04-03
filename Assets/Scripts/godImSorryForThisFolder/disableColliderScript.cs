using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disableColliderScript : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(timer());
    }

    IEnumerator timer()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject.GetComponent<BoxCollider>());
    }
}
