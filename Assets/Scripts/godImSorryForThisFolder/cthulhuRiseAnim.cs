using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cthulhuRiseAnim : MonoBehaviour
{
    public GameObject testThulu;

    private void Start()
    {
        testThulu.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(testThulu.transform.position, transform.position)> 0.01f)
        {
            testThulu.transform.position = Vector3.Lerp(testThulu.transform.position, transform.position, 0.025f);
        }
        else
        {
            testThulu.transform.parent = null;
            testThulu.GetComponent<Rigidbody>().isKinematic = false; //make cthulhu dynamic
            testThulu.GetComponent<AIController>().BeginFollowingPlayer(); //start following the player
            gameObject.SetActive(false);
        }
    }
}
