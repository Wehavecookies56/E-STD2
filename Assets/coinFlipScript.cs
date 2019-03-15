using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinFlipScript : MonoBehaviour
{
    public GameObject particle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void destoycoin()
    {

        playerData.INSTANCE.Intelligence++;
        Destroy(gameObject);
        particle.SetActive(true);
    }
}
