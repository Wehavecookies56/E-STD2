using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioDestroyScript : MonoBehaviour
{
    

    // Update is called once per frame
    void Update()
    {
        if(gameObject.GetComponent<AudioSource>().isPlaying == false)
        {
            Destroy(gameObject);
        }
    }
}
