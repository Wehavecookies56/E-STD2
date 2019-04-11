using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeAnim : MonoBehaviour
{

     public void spin()
     {
        GetComponent<Animator>().SetTrigger("spin");
     }
   
}
