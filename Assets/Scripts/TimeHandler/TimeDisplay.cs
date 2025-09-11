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

    [SerializeField]
    float timeBetweenFlashes = 0.2f;
    [SerializeField]
    float timeBetweenSetsOfFlashes = 1.5f;
    [SerializeField]
    int amountOfFlashes = 5;

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
    public void Flash()
    {
        StartCoroutine(FlashRoutine());
    }
    IEnumerator FlashRoutine()
    {
        for (int i = 0; i < amountOfFlashes; i++)
        {
            image.fillAmount = 1;
            yield return new WaitForSeconds(0.2f);
            image.fillAmount = 0;
            yield return new WaitForSeconds(0.2f);
            image.fillAmount = 1;
            yield return new WaitForSeconds(0.2f);
            image.fillAmount = 0;
            yield return new WaitForSeconds(2f);
        }
    }
}
