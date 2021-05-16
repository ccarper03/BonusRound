using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : Singleton<SoundManager>
{
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

}
