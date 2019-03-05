using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class descriptionManager : MonoBehaviour
{
    public GameObject[] descriptions;
    public enum descriptionType { KEY, AXE, ARMOUR, BOOK, CANDLE, FEATHER, BLACKBOX, CRYSTALBALL };

    public void activateDescription(descriptionType type)
    {
        for (int i = 0; i < descriptions.Length; i++)
        {
            if(descriptions[i].name == descriptions[(int)type].name)
            {
                if (descriptions[(int)type].activeSelf == false)
                {
                    descriptions[(int)type].SetActive(true);
                }
                else
                {
                    descriptions[(int)type].SetActive(false);
                }
            }
            else
            {
                descriptions[i].SetActive(false);
            }
        }       
    }
}
