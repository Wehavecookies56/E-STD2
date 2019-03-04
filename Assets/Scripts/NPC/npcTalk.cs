using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class npcTalk : MonoBehaviour {
    public int currentLine = 0;
    public int lineCount = 1;

    public void playDialog(soundManagerScript.boyAndPriest d) {
        soundManagerScript.audioPlayer.dialogPlay(d, transform);
        nextLine();
    }

    public void playDialog(soundManagerScript.demonSounds d) {
        soundManagerScript.audioPlayer.dialogPlay(d, transform);
        nextLine();
    }

    public void playDialog(soundManagerScript.lawyerAndPriest d) {
        soundManagerScript.audioPlayer.dialogPlay(d, transform);
        nextLine();
    }

    public void playDialog(soundManagerScript.oldManAndPriest d) {
        soundManagerScript.audioPlayer.dialogPlay(d, transform);
        nextLine();
    }

    public void nextLine() {
        if (currentLine + 1 == lineCount) {
            gameObject.layer = 0;
        } else {
            currentLine++;
        }
    }

}
