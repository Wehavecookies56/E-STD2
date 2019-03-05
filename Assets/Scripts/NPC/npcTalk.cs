using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class npcTalk : MonoBehaviour {
    public int currentLine = 0;
    public int lineCount = 1;

    public bool finished = false;

    GameObject currentVoiceLine;

    private void Update() {
        if (currentVoiceLine != null) {
            gameObject.layer = 0;
        } else {
            if (!finished)
                gameObject.layer = 11;
        }
    }

    public void playDialog(soundManagerScript.boyAndPriest d) {
        currentVoiceLine = soundManagerScript.audioPlayer.dialogPlay(d, transform);
        nextLine();
    }

    public void playDialog(soundManagerScript.demonSounds d) {
        soundManagerScript.audioPlayer.dialogPlay(d, transform);
        nextLine();
    }

    public void playDialog(soundManagerScript.lawyerAndPriest d) {
        currentVoiceLine = soundManagerScript.audioPlayer.dialogPlay(d, transform);
        nextLine();
    }

    public void playDialog(soundManagerScript.oldManAndPriest d) {
        currentVoiceLine = soundManagerScript.audioPlayer.dialogPlay(d, transform);
        nextLine();
    }

    public void nextLine() {
        if (currentLine + 1 == lineCount) {
            gameObject.layer = 0;
            currentVoiceLine = null;
            finished = true;
        } else {
            currentLine++;
        }
    }

}
