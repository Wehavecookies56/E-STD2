using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class brainSanityColourChange : MonoBehaviour
{
    void Update()
    {

        if (playerData.INSTANCE.Health <= 1)
        {
            gameObject.GetComponent<Renderer>().material.color = new Color(0.18f, 0.22f, 0.29f);
        }
        else if (playerData.INSTANCE.Health <= 3)
        {
            gameObject.GetComponent<Renderer>().material.color = new Color(0.3f, 0.4f, 0.6f);
        }
        else if (playerData.INSTANCE.Health <= 5)
        {
            gameObject.GetComponent<Renderer>().material.color = new Color(0.7f, 0.79f, 1f);
        }
        else if (playerData.INSTANCE.Health > 5)
        {
            gameObject.GetComponent<Renderer>().material.color = new Color(1, 1, 1);
        }

    }


}
