using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class badEndingCthuluh : MonoBehaviour
{
    public float timer;
    public float speed;
    public float speedSize;
    private bool once = true;

    // Update is called once per frame
    void Update()
    {
        if(timer <= 0)
        {
            if(once)
            {
                gameObject.GetComponent<Animator>().SetTrigger("roar");
                soundManagerScript.audioPlayer.dialogPlay(soundManagerScript.demonSounds.CTHULHUROAR, transform);
                speed = 0;
                once = false;
            }

            transform.localScale += new Vector3(speedSize * Time.deltaTime, speedSize * Time.deltaTime, speedSize * Time.deltaTime);

        }
        else
        {
            timer -= Time.deltaTime;
            transform.position += new Vector3(0,0,speed * Time.deltaTime);

        }

        gameObject.GetComponent<Animator>().SetFloat("speed", Mathf.Abs( speed));


        
    }
}
