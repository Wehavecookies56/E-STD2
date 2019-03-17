using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeTrigger : MonoBehaviour
{
    public Snake snake;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == snake.player)
        {
            snake.state = Snake.States.ENTERING;
            GameObject.Find("soundManager").GetComponent<soundManagerScript>().playOnce(soundManagerScript.enviromentSounds.SNAKEHISS, snake.transform);
            gameObject.SetActive(false);
        }
    }
}
