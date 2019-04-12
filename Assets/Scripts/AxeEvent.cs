using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeEvent : MonoBehaviour
{
    public GameObject Rope;
    public GameObject Axe;
    

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
        if(other.gameObject.CompareTag("Player"))
        {
            Rope.GetComponent<Animator>().SetTrigger("RopeActive");
           
           
        }
    }

   
    /*
     * thigger the event
     * make the axe hurt the player 
     * if coiliston then add rigied body
     * destroy the scrpit 
     * play Anim
     */
}
