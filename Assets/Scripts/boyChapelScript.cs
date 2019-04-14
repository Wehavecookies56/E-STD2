using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boyChapelScript : MonoBehaviour {

    public GameObject boy;
    public Transform pos;
    public GameObject book;
    public GameObject spawnThulhu;
    public GameObject redParticles;
    int line = 0;

    void Start() {
        
    }

    void Update() {
        
    }

    public void moveToChapel() {
        boy.transform.position = pos.position;
        GameObject newBook = Instantiate(book);
        newBook.transform.SetParent(boy.transform);
        StartCoroutine(chant());
    }

    private IEnumerator chant() {
        yield return new WaitForSeconds(20);
        soundManagerScript.audioPlayer.dialogPlay((soundManagerScript.chantSounds)line, GameObject.Find("Player").transform);
        line++;
        if (line == 4) {
            redParticles.SetActive(true);
        }
        if (line == 5) {
            spawnThulhu.SetActive(true);
        }
        if (line < 6) {
            StartCoroutine(chant());
        }
    }

}
