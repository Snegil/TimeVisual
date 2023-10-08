using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VibrateOnEvent : MonoBehaviour
{
    [SerializeField]
    TimeHandler timeHandler;

    void OnEnable()
    {
        timeHandler.TimeHitZero += VibrateWhenEvent;
    }
    void OnDisable()
    {
        timeHandler.TimeHitZero += VibrateWhenEvent;
    }

    public void VibrateWhenEvent() 
    {
        Handheld.Vibrate();
    }
}
