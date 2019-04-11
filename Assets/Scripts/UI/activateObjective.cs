using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activateObjective : MonoBehaviour
{
    public Objectives objectives;
    public Objectives.ObjectivesEnum objectiveToActivate;
    public GameObject optionalFakeDoor;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (objectiveToActivate == Objectives.ObjectivesEnum.OpenRitualDoor)
            {
                if (optionalFakeDoor != null)
                {
                    if(optionalFakeDoor.activeSelf)
                    {
                        objectives.ActivateObjective(objectiveToActivate);
                    }
                }
            }
            else
            {
                objectives.ActivateObjective(objectiveToActivate);
            }
        }
    }
}
