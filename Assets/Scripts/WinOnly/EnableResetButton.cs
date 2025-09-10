using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableResetButton : MonoBehaviour
{
    [SerializeField]
    TimeHandler timeHandler;

    [SerializeField]
    GameObject objectToToggle;

    void OnEnable()
    {
        timeHandler.TimeChanged += ToggleOnEvent;
    }
    void OnDisable()
    {
        timeHandler.TimeChanged -= ToggleOnEvent;
    }
    void ToggleOnEvent(float time)
    {
        if (time > 0)
        {
            objectToToggle.SetActive(true);
            return;
        }
        objectToToggle.SetActive(false);
        return;
    }
}
