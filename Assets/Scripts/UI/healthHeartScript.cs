using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthHeartScript : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        
         if (playerData.INSTANCE.Health <= 1)
         {
             gameObject.GetComponent<Renderer>().material.color = new Color(0.27f, 0.49f, 0.26f);
         }
         else if (playerData.INSTANCE.Health <= 3)
         {
              gameObject.GetComponent<Renderer>().material.color = new Color(0.32f, 0.58f, 0.38f);
         }
         else if (playerData.INSTANCE.Health <= 5)
         {
             gameObject.GetComponent<Renderer>().material.color = new Color(0.59f, 0.84f, 0.64f);
         }
         else if (playerData.INSTANCE.Health > 5)
         {
             gameObject.GetComponent<Renderer>().material.color = new Color(1, 1, 1);
         }
         
    }
}
