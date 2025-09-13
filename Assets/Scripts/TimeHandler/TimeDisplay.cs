using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeDisplay : MonoBehaviour
{
    [SerializeField]
    TimeHandler timeHandler;

    float maxTime = 60 * 60;

    Image image;

    void Start()
    {
        image = GetComponent<Image>();
    }

    // Start is called before the first frame update
    void OnEnable()
    {
        timeHandler.TimeChanged += DisplayTime;
    }
    void OnDisable()
    {
        timeHandler.TimeChanged -= DisplayTime;
    }
    public void TimeMaximum(float maxTimeInMinutes)
    {
        maxTime = maxTimeInMinutes * 60;
    }
    void DisplayTime(float time)
    {
        image.fillAmount = time / maxTime;
    }
}
