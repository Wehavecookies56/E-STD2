//Written by Dan Sheshtanov
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; //Text mesh pro

public class Objectives : MonoBehaviour
{
    public TextMeshProUGUI textBox;
    public Animator textNotification;
    public GameObject journal;

    public enum ObjectivesEnum
    {
        ExploreManor,

        TalkToOldMan,
        FindBoy,
        TalkToBoy,
        TalkToLawyer,

        InspectPiano,
        FindMirrorItem,

        FindAxe,
        DestroyDoor,
        FindKey,

        OpenTrapDoor,
        OpenRitualDoor,

        FlipCoin
    }

    private List<ObjectivesEnum> activeObjectives = new List<ObjectivesEnum>();
    private List<ObjectivesEnum> completedObjectives = new List<ObjectivesEnum>();

    private string[] objStrings = new string[]
    {
        "Explore the Manor",

        "Talk to the old scientist",
        "Find the boy",
        "Talk to the boy",
        "Talk to the lawyer",

        "Inspect the piano, it seems off-tune",
        "Find something that the mirror wants",

        "Find a way to destroy the broken door",
        "Destroy the broken door with the axe",
        "Find a key for the locked door on ground floor",

        "Find a way to open the trap door",
        "Find a way to open the signed door",

        "Flip the coin in the chest"
    };

    public bool IsObjectiveComplete(ObjectivesEnum o)
    {
        //check if objective on complete list
        foreach (ObjectivesEnum oi in completedObjectives)
        {
            //return true if complete
            if(o == oi) { return true; }
        }
        //return false if not complete
        return false;
    }

    public bool IsObjectiveActive(ObjectivesEnum o)
    {
        //check if objective on complete list
        foreach (ObjectivesEnum oi in activeObjectives)
        {
            //return true if complete
            if (o == oi) { return true; }
        }
        //return false if not complete
        return false;
    }

    public void ActivateObjective(ObjectivesEnum o)
    {
        //check if objective already added
        foreach (ObjectivesEnum oi in activeObjectives)
        {
            if( o == oi ) { Debug.Log("Task \"" + objStrings[(int)o] + "\" already active!"); return; }
        }

        //add objective to list of objectives
        activeObjectives.Add(o);
        //add related string to list of objectives
        textBox.text = textBox.text + objStrings[(int)o] + "\n";

        //play text animation
        NotifyPlayer();
    }

    private void NotifyPlayer()
    {
        textNotification.SetTrigger("Notify");
        //make journal scroll out seb
        journal.GetComponent<Animator>().SetTrigger("show");
    }

    private void DeactivateObjective(ObjectivesEnum o)
    {
        //non-funcitonal
    }

    public void CompleteObjective(ObjectivesEnum o)
    {
        //flag to check if objective was found
        bool isFound = false;

        //check if objective already complete
        foreach (ObjectivesEnum oi in completedObjectives)
        {
            if (o == oi) { return; }
        }

        //save all lines into an array temporarily
        string[] textLines = textBox.text.Split('\n');

        //replace desired string with a strikethrough version
        for (int i = 0; i < activeObjectives.Count; i++)
        {
            if(o == activeObjectives[i])
            {
                textLines[i] = "<s>" + textLines[i] + "</s>";
                completedObjectives.Add(o);
                isFound = true;
            }
        }

        //doesn't force activate an objective on completion
        //if (!isFound) { Debug.Log("No task \"" + objStrings[(int)o] + "\" was found!"); return; }
        //does force activate an objective on completion and force completion
        if(!isFound)
        {
            ActivateObjective(o); //activate
            textLines = textBox.text.Split('\n'); //re-scan current paragraph in text box
            CompleteObjective(o); //mark as complete
            return; //dont carry out the code below as it will revert back to incomplete state (visually)
        }

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

        NotifyPlayer();
    }
}
