using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : Singleton<SoundManager>
{
    [SerializeField] private AudioClip highClick;
    [SerializeField] private AudioClip lowClick;
    [SerializeField] private AudioClip alright;
    [SerializeField] private AudioClip anticipation;
    [SerializeField] private AudioClip hooray;
    [SerializeField] private AudioClip nice;
    [SerializeField] private AudioClip whoa;
    [SerializeField] private AudioClip wrong;
    [SerializeField] private AudioClip playClick;
    public AudioClip IncreaseClick => highClick;
    public AudioClip DecreaseClick => lowClick;
    public AudioClip Alright => alright;
    public AudioClip Anticipation => anticipation;
    public AudioClip Hooray => hooray;
    public AudioClip Nice => nice;
    public AudioClip Whoa => whoa;
    public AudioClip Wrong => wrong;
    public AudioClip PlayClick => playClick;

}
