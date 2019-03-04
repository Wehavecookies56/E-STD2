using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum InputDevice {
    KEYBOARD, CONTROLLER
}

public class tooltipScript : MonoBehaviour {    

    public InputDevice lastUsed = InputDevice.KEYBOARD;

    public Dictionary<string, Image> prompts = new Dictionary<string, Image>();

    GameObject text;
    GameObject buttonPrompt;

    GameObject player;

    // Start is called before the first frame update
    void Start() {
        text = transform.GetChild(0).gameObject;
        buttonPrompt = transform.GetChild(1).gameObject;
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update() {
        lastUsed = GetLastUsed();

        if (player.GetComponent<playerInteract>().lastLookedAt == null) {
            GetComponent<CanvasGroup>().alpha = 0;
        } else {
            string action = player.GetComponent<playerInteract>().lastLookedAt.GetComponent<objectScript>().data.Type.ToString();
            action = action.ToLower();
            action = action.Substring(0, 1).ToUpper() + action.Substring(1, action.Length-1);
            GetComponent<CanvasGroup>().alpha = 1;
            text.GetComponent<Text>().text = action + "\n" + player.GetComponent<playerInteract>().lastLookedAt.name;
            if (lastUsed == InputDevice.CONTROLLER) {
                buttonPrompt.GetComponent<Image>().sprite = Resources.Load<Sprite>("a button");
            } else {
                buttonPrompt.GetComponent<Image>().sprite = Resources.Load<Sprite>("e key");
            }
        }
    }

    InputDevice GetLastUsed() {
        if (Input.GetJoystickNames().Length != 0) {
            for (int i = (int)KeyCode.JoystickButton0; i <= (int)KeyCode.JoystickButton19; i++) {
                if (Input.GetKey((KeyCode)i)) {
                    //Change controller prompts to controller type
                    return InputDevice.CONTROLLER;
                }
            }
        }

        for (int i = (int)KeyCode.Backspace; i <= (int)KeyCode.Mouse6; i++) {
            if (Input.GetKey((KeyCode)i)) {
                //If any key or mouse button is pressed switch to keyboard and mouse prompts
                return InputDevice.KEYBOARD;
            }
        }
        return lastUsed;
    }

}
