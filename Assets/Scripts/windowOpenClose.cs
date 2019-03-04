using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class windowOpenClose : MonoBehaviour
{
    public float topstop = 1.6f;
    private float startY;  
    public float speed = 1;
    public bool opening = false;

    // Start is called before the first frame update
    void Start()
    {
        startY = transform.position.y; 
    }

    // Update is called once per frame
    void Update()
    {
        if (opening)
        {

            if (transform.position.y <startY + topstop)
            {
                transform.Translate(new Vector3(0, Time.deltaTime * speed, 0));
            }
            else
            {
                transform.position = new Vector3(transform.position.x, startY + topstop, transform.position.z);
            }
        }

    }
}
