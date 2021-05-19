using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : Singleton<SoundManager>
{
<<<<<<< HEAD
    [SerializeField] private AudioClip increaeClick;
    [SerializeField] private AudioClip decreaseClick;
    [SerializeField] private AudioClip nice;
    [SerializeField] private AudioClip hooray;
    [SerializeField] private AudioClip alright;
    [SerializeField] private AudioClip pooper;
    [SerializeField] private AudioClip anticipation;
    [SerializeField] private AudioClip whoa;
    public AudioClip IncreaseClick => increaeClick;
    public AudioClip DecreaseClick => decreaseClick;
    public AudioClip Nice => nice;
    public AudioClip Hooray => hooray;
    public AudioClip Alright => alright;
    public AudioClip Anticipation => anticipation;
    public AudioClip Pooper => pooper;
    public AudioClip Whoa => whoa;
=======
=======
>>>>>>> parent of 7f8585f (added some sounds, working on a bug it the Chest class.)
    [SerializeField] private AudioClip highClick;
    public AudioClip IncreaseClick 
    {
        get { return highClick; } 
    }

    [SerializeField] private AudioClip lowClick;
    public AudioClip DecreaseClick 
    {
        get { return lowClick; }
    }

>>>>>>> parent of 7f8585f (added some sounds, working on a bug it the Chest class.)
=======
>>>>>>> parent of 7f8585f (added some sounds, working on a bug it the Chest class.)
}
