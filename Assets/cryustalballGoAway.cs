using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cryustalballGoAway : MonoBehaviour
{
    
    // Update is called once per frame
    void Update()
    {
       
        if(GameObject.FindGameObjectWithTag("crystalballui").GetComponent<CanvasGroup>().alpha == 1)
        {
            StartCoroutine(turnOffAfterTime());
        }
    }

    IEnumerator turnOffAfterTime()
    {
        yield return new WaitForSeconds(4);
        Time.timeScale = 1;
        GameObject.FindGameObjectWithTag("crystalBallLights").GetComponent<LightPlayerDetector>().enabled = true;
        GameObject.FindGameObjectWithTag("crystalBallLights2").GetComponent<LightPlayerDetector>().enabled = true;
        gameObject.SetActive(false);
        //GameObject.FindGameObjectWithTag("crystalballui").GetComponent<CanvasGroup>().alpha = 0;
        //GameObject.FindGameObjectWithTag("crystalballui").GetComponent<CanvasGroup>().blocksRaycasts = false;
    }
}
