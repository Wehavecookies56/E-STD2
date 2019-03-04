using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inventoryStatsManager : MonoBehaviour
{
    public Text[] stats;

    private void Update()
    {
        stats[0].text = playerData.INSTANCE.Strength.ToString();
        stats[1].text = playerData.INSTANCE.Agility.ToString();
        stats[2].text = playerData.INSTANCE.Intelligence.ToString();
        stats[3].text = playerData.INSTANCE.Willpower.ToString();
        stats[4].text = playerData.INSTANCE.Perception.ToString();
        stats[5].text = playerData.INSTANCE.Charisma.ToString();

    }
}
