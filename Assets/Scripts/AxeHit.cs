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
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
           // Rope.GetComponent<Animator>().SetBool("Hit", true);
            //enbale rigaed body
            GameObject myGameObject = new GameObject("Test Object");
            Rigidbody gameObjectsRigidBody = myGameObject.AddComponent<Rigidbody>();
            playerData.INSTANCE.Health -= 1; //hurt player
            Destroy(GetComponent<AxeHit>());
            //disable script
        }
    }
}
