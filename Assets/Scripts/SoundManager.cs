using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : Singleton<SoundManager>
{
    [SerializeField] private AudioClip increaeClick;
    [SerializeField] private AudioClip decreaseClick;
    [SerializeField] private AudioClip nice;
    [SerializeField] private AudioClip hooray;
    [SerializeField] private AudioClip alright;
    [SerializeField] private AudioClip pooper;
    [SerializeField] private AudioClip anticipation;
    public AudioClip IncreaseClick => increaeClick;
    public AudioClip DecreaseClick => decreaseClick;
    public AudioClip Nice => nice;
    public AudioClip Hooray => hooray;
    public AudioClip Alright => alright;
    public AudioClip Anticipation => anticipation;
    public AudioClip Pooper => pooper;
}
