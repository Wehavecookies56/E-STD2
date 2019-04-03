using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class soundManagerScript : MonoBehaviour
{
    public static soundManagerScript audioPlayer { get; private set; }

    //chant
    public enum chantSounds { BOY1, BOY2, BOY3, BOY4, BOY5, BOY6 };
    public GameObject[] Chantaudio;

    //meeting in basement
    public enum basemnetMeetingSounds { OLDMAN1, LAWYER2 };
    public GameObject[] MeetingSounds;

    //demon sounds
    public enum demonSounds { CONTRACT, BREAKME, IAMTHEFLOOR, INSIST, HA, THANKYOU, WHATINEED, RATS, CTHULHUROAR };
    public GameObject[] demonAudio;

    //thater
    public enum demonSoundsTheater { CONTRACT, NO1, INSIST, NO2 };
    public GameObject[] demonAudioTheater;

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
    public enum Priest { PRARE1, PRARE2, JHONNY, HURT, BADENDINGN, GOODENDING, CRAZYENDING };
    public GameObject[] PriestAudio;

    public enum enviromentSounds { DOOROPEN, THUNDER1, THUNDER2, GHOSTSCREAM, POTBREAK, THUNDER3, THUNDER4, WINDOW, CHESTOPEN, AXEIMPACT, SNAKEHISS, STATUELAUGH, SCREAM };
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

    public GameObject subtitleObject;
    List<string> oldManAndPriestSubtitles = new List<string> {
        "Old Man: Have you seen a boy around here?",
        "Estder D. Donovan: We have.",
        "Old Man: Where is he?",
        "Estder D. Donovan: I don't think I should tell you.",
        "Old Man: I need him for my experiements.",
        "Estder D. Donovan: You are on the wrong path, God is watching.",
        "Old Man: Okay. No matter, whatever happens do not wear the armour."
    };

    List<string> lawyerAndPriestSubtitles = new List<string> {
        "Morpheus: What is a priest doing here?",
        "Estder D. Donovan: I'm here in the name of the lord.",
        "Morpheus: Have you found anything of interest?",
        "Estder D. Donovan: No.",
        "Morpheus: Okay, I'll look around. If I find anything I'll let you know."
    };

    List<string> boyAndPriestSubtitles = new List<string> {
        "Boy: Oh I'm sorry.",
        "Estder D. Donovan: It's fine my child all is forgiven.",
        "Boy: Screw you!"
    };

    List<string> priestSubtitles = new List<string> {
        "Estder D. Donovan: Ave Maria, Gratia plena, Dominus tecum, Benedicta tu in mulieribus, Amen.",
        "Estder D. Donovan: Filium eius unicum, Dominum nostrum, qui conceptus est de Spiritu Sancto.",
        "Estder D. Donovan: HERE'S JOHNNY!",
        "(Estder D. Donovan Hurt)"
    };

    List<string> demonSubtitles = new List<string> {
        "Demon: Here a contract in exchange for your power.",
        "Gold Plate: Break me.",
        "Book: I am the floor.",
        "Demon: I insist.",
        "Demon: Ha.",
        "Mirror: Thank you.",
        "Mirror: You don't have what I need.",
        "(Rat noises)"
    };

    List<string> basementMeetingSubtitles = new List<string> {
        "Old Man: We need to kill the boy!",
        "Morpheus: No we should destroy the book!"
    };

    List<string> chantSubtitles = new List<string> {
        "Boy: Beneath the hunter's moon, they are unleashing all but soon",
        "Boy: Bright blue light fire up the room, the legions are ready to bring your doom",
        "Boy: The house at R'lyeh dead Cthulhu waits dreaming...",
        "Boy: ...That's not dead, which can eternal lie, and with strange eons, even death may die!",
        "Boy: Elder one, awaken from your ancient slumber, and answer my calling...",
        "Boy: Ph'nglui mglw'nafh Cthulhu R'lyeh wgah'nagl fhtagn!!"
    };

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
        subtitleObject.GetComponent<Text>().text = demonSubtitles[(int)sound];
        subtitleObject.GetComponent<subtitleHide>().lastPlayed = instance;
        instance = null;
    }
    //=====================================================================

    public GameObject dialogPlay(boyAndPriest sound, Transform position)
    {
        GameObject instance = Instantiate(boyPriestAudio[(int)sound]);
        instance.transform.position = transform.position;
        subtitleObject.GetComponent<Text>().text = boyAndPriestSubtitles[(int)sound];
        subtitleObject.GetComponent<subtitleHide>().lastPlayed = instance;
        return instance;
    }

    public GameObject dialogPlay(lawyerAndPriest sound, Transform position)
    {
        GameObject instance = Instantiate(lawyerAndPriestAudio[(int)sound]);
        instance.transform.position = transform.position;
        subtitleObject.GetComponent<Text>().text = lawyerAndPriestSubtitles[(int)sound];
        subtitleObject.GetComponent<subtitleHide>().lastPlayed = instance;
        return instance;
    }

    public GameObject dialogPlay(oldManAndPriest sound, Transform position)
    {
        GameObject instance = Instantiate(oldManPriestAudio[(int)sound]);
        instance.transform.position = transform.position;
        subtitleObject.GetComponent<Text>().text = oldManAndPriestSubtitles[(int)sound];
        subtitleObject.GetComponent<subtitleHide>().lastPlayed = instance;
        return instance;
    }

    public GameObject dialogPlay(Priest sound, Transform position)
    {
        GameObject instance = Instantiate(PriestAudio[(int)sound]);
        instance.transform.position = transform.position;
        subtitleObject.GetComponent<Text>().text = priestSubtitles[(int)sound];
        subtitleObject.GetComponent<subtitleHide>().lastPlayed = instance;
        return instance;
    }

    public GameObject dialogPlay(basemnetMeetingSounds sound, Transform position)
    {
        GameObject instance = Instantiate(MeetingSounds[(int)sound]);
        instance.transform.position = transform.position;
        subtitleObject.GetComponent<Text>().text = basementMeetingSubtitles[(int)sound];
        subtitleObject.GetComponent<subtitleHide>().lastPlayed = instance;
        return instance;
    }

    public GameObject dialogPlay(chantSounds sound, Transform position)
    {
        GameObject instance = Instantiate(Chantaudio[(int)sound]);
        instance.transform.position = transform.position;
        subtitleObject.GetComponent<Text>().text = chantSubtitles[(int)sound];
        subtitleObject.GetComponent<subtitleHide>().lastPlayed = instance;
        return instance;
    }

    public GameObject dialogPlay(demonSoundsTheater sound, Transform position)
    {
        GameObject instance = Instantiate(demonAudioTheater[(int)sound]);
        instance.transform.position = transform.position;
        //subtitleObject.GetComponent<Text>().text = chantSubtitles[(int)sound];
        //subtitleObject.GetComponent<subtitleHide>().lastPlayed = instance;
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
