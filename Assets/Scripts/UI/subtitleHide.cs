using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class subtitleHide : MonoBehaviour {

    public GameObject lastPlayed;
    float alpha = 1.0F;
    bool fading = false;

    void Update() {
        Text t = GetComponent<Text>();
        if (lastPlayed == null && GetComponent<Text>().text.Length > 0 && !fading && alpha == 1.0F) {
            fading = true;
        }
        if (fading) {
            t.color = new Color(t.color.r, t.color.g, t.color.b, alpha -= Time.deltaTime);
            if (alpha <= 0) {
                fading = false;
            }
        }
        if (lastPlayed != null) {
            alpha = 1.0F;
            t.color = new Color(t.color.r, t.color.g, t.color.b, alpha);
        }
    }
}
