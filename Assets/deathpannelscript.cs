using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deathpannelscript : MonoBehaviour
{
    public GameObject player;

    private void Start()
    {
        StartCoroutine(thisisit());
    }

    IEnumerator thisisit()
    {
        player.SetActive(false);
        yield return new WaitForSeconds(4);
        Application.Quit();
    }
}
