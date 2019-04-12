using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeAnim : MonoBehaviour
{

     public void spin()
     {
        //make it stay in its current posiston 
        gameObject.transform.Rotate(new Vector3(0, 0, 90));
        GetComponent<Animator>().SetTrigger("Spin");
     }
   
}
