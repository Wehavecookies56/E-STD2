using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevilTrigger : MonoBehaviour
{
    public GameObject Devil;
    internal bool KeepGoing = false;
    public GameObject mainBlueFire;
    public GameObject mainredFire;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if (KeepGoing == true)
        {

            Devil.transform.position = Vector3.MoveTowards(Devil.transform.position, Devil.transform.forward + Devil.transform.position, 2 * Time.deltaTime);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // freave the players movement 
            //play devil walk anim
            //maybe sound 
            mainBlueFire.SetActive(true);
            mainredFire.SetActive(true);
            Devil.SetActive(true);
            KeepGoing = true;

        }
    }
}
