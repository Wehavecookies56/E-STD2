using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundManagerScript : MonoBehaviour
{
    public static soundManagerScript audioPlayer { get; private set; }

    //demon sounds
    public enum demonSounds { CONTRACT, BREAKME, IAMTHEFLOOR, INSIST, HA, THANKYOU, WHATINEED, RATS };
    public GameObject[] demonAudio;

    //boy and priest
    public enum boyAndPriest { BOY1, PRIEST2, BOY2 };
    public GameObject[] boyPriestAudio;

    //old man and priest
    public enum oldManAndPriest { OLDMAN1, PRIEST2 , OLDMAN3, PRIEST4, OLDMAN5, PRIEST6, OLDMAN7};
    public GameObject[] oldManPriestAudio;

    //lawyer priest
    public enum lawyerAndPriest {LAWYER1, PRIEST2, LAWYER3, PRIEST4, LAWYER5 };
    public GameObject[] lawyerAndPriestAudio;

    //priestSounds
    public enum Priest { PRARE1, PRARE2, JHONNY, HURT };
    public GameObject[] PriestAudio;

    public enum enviromentSounds { DOOROPEN, THUNDER1, THUNDER2, GHOSTSCREAM, POTBREAK, THUNDER3, THUNDER4, WINDOW, CHESTOPEN, AXEIMPACT };
    public GameObject[] enviromentAudio;

    public enum backgroundSounds { HORRORLOOP, RAINLOOP };
    public GameObject[] backroundSounds;

    //UI sounds
    public enum UIsounds { SCROLLOPEN, SCROLLCLOSED, GETITEM, BUTTONCLICKED};
    public GameObject[] Uisounds;

    public enum footsteps { WOOD };
    public GameObject[] footstepsSound;
    public float MaxFootstepVolume;
    private GameObject footstepsInstance;
    bool created = false;

    private GameObject sanityAudio;

    private void Awake()
    {
        if (audioPlayer == null)
        {
            audioPlayer = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        startLoop(backgroundSounds.HORRORLOOP, gameObject.transform);
        startLoop(backgroundSounds.RAINLOOP, gameObject.transform);
    }

    private void Update()
    {
        setSanityAudioVolume();
    }

    public void playOnce(enviromentSounds sound, Transform position)
    {
        GameObject instance = Instantiate(enviromentAudio[(int)sound]);
        instance.transform.position = transform.position;
        instance = null;
    }

    public void playOnce(UIsounds sound, Transform position)
    {
        GameObject instance = Instantiate(Uisounds[(int)sound]);
        instance.transform.position = transform.position;
        instance = null;
    }

    public void dialogPlay(demonSounds sound, Transform position)
    {
        GameObject instance = Instantiate(demonAudio[(int)sound]);
        instance.transform.position = transform.position;
        instance = null;
    }
    //=====================================================================

    public GameObject dialogPlay(boyAndPriest sound, Transform position)
    {
        GameObject instance = Instantiate(boyPriestAudio[(int)sound]);
        instance.transform.position = transform.position;
        return instance;
    }

    public GameObject dialogPlay(lawyerAndPriest sound, Transform position)
    {
        GameObject instance = Instantiate(lawyerAndPriestAudio[(int)sound]);
        instance.transform.position = transform.position;
        return instance;
    }

    public GameObject dialogPlay(oldManAndPriest sound, Transform position)
    {
        GameObject instance = Instantiate(oldManPriestAudio[(int)sound]);
        instance.transform.position = transform.position;
        return instance;
    }

    public GameObject dialogPlay(Priest sound, Transform position)
    {
        GameObject instance = Instantiate(PriestAudio[(int)sound]);
        instance.transform.position = transform.position;
        return instance;
    }
    //============================================================================
    public void startLoop(backgroundSounds sound, Transform parent)
    {
        GameObject instance = Instantiate(backroundSounds[(int)sound]);
        if(sound == backgroundSounds.HORRORLOOP)
        {
            sanityAudio = instance;
        }
        instance.transform.SetParent(parent);
    }

    public void FootSteps(footsteps type, Transform parent, float speed)
    {
        
        if(created == false)
        {
            footstepsInstance = Instantiate(footstepsSound[(int)type]);
            footstepsInstance.transform.SetParent(parent);
            created = true;
        }
        
        if(Mathf.Abs(speed) > 0.1f)
        {
            footstepsInstance.GetComponent<AudioSource>().volume = MaxFootstepVolume;
        }
        else if(Mathf.Abs(speed) < 0.1f)
        {
            footstepsInstance.GetComponent<AudioSource>().volume = 0f;
        }
    }

    public void setSanityAudioVolume()
    {
        sanityAudio.GetComponent<AudioSource>().volume = 0.6f - (playerData.INSTANCE.Sanity / 10);
    }
    

}
