using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevilTrigger : MonoBehaviour
{
    public GameObject Devil;

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
            // freave the players movement 
            //play devil walk anim
            //maybe sound 
            Devil.SetActive(true);   
        }
    }
}
