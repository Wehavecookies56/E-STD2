using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeHit : MonoBehaviour
{

    public GameObject Rope;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Rope.GetComponent<Animator>().SetTrigger("Hit");
            //enbale rigaed body
            GameObject myGameObject = new GameObject("Test Object");
            Rigidbody gameObjectsRigidBody = myGameObject.AddComponent<Rigidbody>();
            playerData.INSTANCE.Health -= 1; //hurt player

            //disable script
        }
    }
}
