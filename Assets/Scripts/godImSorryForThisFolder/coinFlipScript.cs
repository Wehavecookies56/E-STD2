using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinFlipScript : MonoBehaviour
{
    public GameObject particle;

  
    public void destoycoin()
    {

        playerData.INSTANCE.Intelligence++;
        particle.SetActive(true);
        Destroy(gameObject);
    }
}
