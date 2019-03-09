using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScript : MonoBehaviour {

    Text t;

    void Start() {
        t = GetComponent<Text>();
        StartCoroutine(loadScene());
    }

    float counter;

    void Update() {
        counter += Time.deltaTime;
        Debug.Log(counter);
        if (counter >= 1) {
            counter = 0;
            t.text += ".";
        }
    }

    IEnumerator loadScene() {
        AsyncOperation asyncLoading = SceneManager.LoadSceneAsync(1);
        asyncLoading.allowSceneActivation = false;
        while (!asyncLoading.isDone && GameObject.Find("loading").GetComponent<AudioSource>().isPlaying) {
            yield return null;
        }
        asyncLoading.allowSceneActivation = true;
    }
}
