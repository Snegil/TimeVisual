using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayAudio : MonoBehaviour
{
    AudioSource audioSrc;

    bool playSound;

    [SerializeField]
    float timer;
    float setTimer;

    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
        setTimer = timer;
    }
    void Update()
    {
        if (playSound == true)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                audioSrc.Play();
                //TODO: FIX VIBRATION ON PHONES
                //Handheld.Vibrate();
                timer = setTimer;
            }
        }
    }
    void OnEnable()
    {
        playSound = true;
    }
    private void OnDisable()
    {
        playSound = false;
        timer = setTimer;
    }
}
