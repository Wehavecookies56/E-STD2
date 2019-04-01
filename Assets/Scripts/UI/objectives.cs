//Written by Dan Sheshtanov
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; //Text mesh pro

public class objectives : MonoBehaviour
{
    public TextMeshProUGUI textBox;
    public Text textNotification;

    public enum ObjectivesEnum
    {
        ExploreManor,

        TalkToOldMan,
        FindBoy,
        TalkToBoy,

        InspectPiano,
        FindMirrorItem,

        FindAxe,
        DestroyDoor,
        FindKey,

        OpenTrapDoor,
        OpenRitualDoor,

        FlipCoin
    }

    private List<ObjectivesEnum> activeStrings = new List<ObjectivesEnum>();

    private string[] objStrings = new string[]
    {
        "Explore the Manor",

        "Talk to the old scientist",
        "Find the boy",
        "Talk to the boy",

        "Inspect the piano, it seems off-tune",
        "Find something that the mirror wants",

        "Find a way to destroy the broken door",
        "Destroy the broken door with the axe",
        "Find a key for the locked door on ground floor",

        "Find a way to open the trap door",
        "Find a way to open the signed door",

        "Flip the coin in the chest"
    };

    private void NotifyPlayer()
    {
        textNotification.GetComponent<Animator>().SetTrigger("Notify");
    }

    public void ActivateObjective(ObjectivesEnum o)
    {
        activeStrings.Add(o);
        textBox.text = textBox.text + objStrings[(int)o] + "\n";

        //TODO journal entry added fade in and out
    }

    private void DeactivateObjective(ObjectivesEnum o)
    {
        //non-funcitonal
    }

    public void CompleteObjective(ObjectivesEnum o)
    {
        //flag to check if objective was found
        bool isFound = false;
        //save all lines into an array temporarily
        string[] textLines = textBox.text.Split('\n');

        //replace desired string with a strikethrough version
        for (int i = 0; i < activeStrings.Count; i++)
        {
            if(o == activeStrings[i]) { textLines[i] = "<s>" + textLines[i] + "</s>"; isFound = true; }
        }

        if (!isFound) { Debug.Log("No task " + objStrings[(int)o] + " was found!"); return; }

        //clear text box
        textBox.text = "";

        //read all strings into text box
        foreach (string s in textLines)
        {
            textBox.text = textBox.text + s + "\n";
        }

        //trim all excess new line characters at the end
        textBox.text = textBox.text.TrimEnd('\n');
        //add one new line for the end
        textBox.text = textBox.text + '\n';
    }
}
