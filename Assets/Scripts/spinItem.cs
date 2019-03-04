using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spinItem : MonoBehaviour
{
    public bool go = false;

    private void Update()
    {
        if(gameObject.tag == "armour")
        {
            if(go == true)
            {
                GameObject.FindGameObjectWithTag("armourModel").transform.Rotate(0, 1, 0, Space.World);
            }
            else
            {
                GameObject.FindGameObjectWithTag("armourModel").transform.Rotate(0, 0, 0, Space.World);
            }
        }

        if (gameObject.tag == "key")
        {
            if (go == true)
            {
                GameObject.FindGameObjectWithTag("keyModel").transform.Rotate(0, 1, 0, Space.World);
            }
            else
            {
                GameObject.FindGameObjectWithTag("keyModel").transform.Rotate(0, 0, 0, Space.World);
            }
        }

        if (gameObject.tag == "axe")
        {
            if (go == true)
            {
                GameObject.FindGameObjectWithTag("axeModel").transform.Rotate(0, 1, 0, Space.World);
            }
            else
            {
                GameObject.FindGameObjectWithTag("axeModel").transform.Rotate(0, 0, 0, Space.World);
            }
        }

        if (gameObject.tag == "book")
        {
            if (go == true)
            {
                GameObject.FindGameObjectWithTag("bookModel").transform.Rotate(0, 1, 0, Space.World);
            }
            else
            {
                GameObject.FindGameObjectWithTag("bookModel").transform.Rotate(0, 0, 0, Space.World);
            }
        }

        if (gameObject.tag == "candle")
        {
            if (go == true)
            {
                GameObject.FindGameObjectWithTag("candleModel").transform.Rotate(0, 1, 0, Space.World);
            }
            else
            {
                GameObject.FindGameObjectWithTag("candleModel").transform.Rotate(0, 0, 0, Space.World);
            }
        }

        if (gameObject.tag == "feather")
        {
            if (go == true)
            {
                GameObject.FindGameObjectWithTag("featherModel").transform.Rotate(0, 1, 0, Space.World);
            }
            else
            {
                GameObject.FindGameObjectWithTag("featherModel").transform.Rotate(0, 0, 0, Space.World);
            }
        }

        if (gameObject.tag == "blackBox")
        {
            if (go == true)
            {
                GameObject.FindGameObjectWithTag("blackBoxModel").transform.Rotate(0, 1, 0, Space.World);
            }
            else
            {
                GameObject.FindGameObjectWithTag("blackBoxModel").transform.Rotate(0, 0, 0, Space.World);
            }
        }
    }
}
