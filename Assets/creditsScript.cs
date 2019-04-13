using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class creditsScript : MonoBehaviour
{
    public GameObject player;
    public GameObject mainCam;
    public Transform[] camPos;
    public GameObject[] names;
    public GameObject UI;
    public GameObject blackPannel;
    private int counter = 0;


    IEnumerator switchCam(float time)
    {
        UI.SetActive(false);
        mainCam.transform.parent = null;
        player.SetActive(false);
        player.transform.position = camPos[counter].position;
        mainCam.transform.position = camPos[counter].position;
        mainCam.transform.rotation = camPos[counter].rotation;
        names[counter].SetActive(true);
        blackPannel.SetActive(true);
        counter++;
        yield return new WaitForSeconds(time);
        blackPannel.SetActive(false);
        blackPannel.SetActive(true);
        player.transform.position = camPos[counter].position;
        mainCam.transform.position = camPos[counter].position;
        mainCam.transform.rotation = camPos[counter].rotation;
        names[counter].SetActive(true);
        counter++;
        yield return new WaitForSeconds(time);
        blackPannel.SetActive(false);
        blackPannel.SetActive(true);
        player.transform.position = camPos[counter].position;
        mainCam.transform.position = camPos[counter].position;
        mainCam.transform.rotation = camPos[counter].rotation;
        names[counter].SetActive(true);
        counter++;
        yield return new WaitForSeconds(time);
        blackPannel.SetActive(false);
        blackPannel.SetActive(true);
        player.transform.position = camPos[counter].position;
        mainCam.transform.position = camPos[counter].position;
        mainCam.transform.rotation = camPos[counter].rotation;
        names[counter].SetActive(true);
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        blackPannel.SetActive(false);
        blackPannel.SetActive(true);

    }

    private void Start()
    {
        StartCoroutine(switchCam(7));
    }



}
