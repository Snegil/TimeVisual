using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudioOnEvent : MonoBehaviour
{
    [SerializeField]
    AudioSource audioSrc;
    
    public void PlayAudio()
    {
        audioSrc.Play();
        Handheld.Vibrate();
    }
}
