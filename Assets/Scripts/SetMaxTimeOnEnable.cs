using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetMaxTimeOnEnable : MonoBehaviour
{
    [Space, SerializeField, Header("TimeDisplay Script")]
    TimeDisplay timeDisplay;
    [SerializeField, Header("TimeHandler Script")]
    TimeHandler timeHandler;

    [Space, SerializeField, Header("Max Time in MINUTES")]
    float maxTime;

    private void OnEnable()
    {
        timeDisplay.TimeMaximum(maxTime);
        timeHandler.ResetTime();
    }
}
