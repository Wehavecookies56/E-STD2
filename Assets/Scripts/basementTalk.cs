using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basementTalk : MonoBehaviour {

    public soundManagerScript.basemnetMeetingSounds voiceline;

    public void playDialog() {
        soundManagerScript.audioPlayer.dialogPlay(voiceline, transform);
        gameObject.layer = 0;
    }

}
