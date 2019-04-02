using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DveilStopWlaking : MonoBehaviour
{
    public GameObject Devil;
    public GameObject DevilTrigger ;
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
        if (other.gameObject.CompareTag("Devil"))
        {
            Devil.GetComponent<Animator>().SetTrigger("EnterIdle");
            DevilTrigger.GetComponent<DevilTrigger>().KeepGoing = false;
           
            Destroy(DevilTrigger);
            //disable walk anim
            //play idle anim
        }
    }
}
