using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TimeFlashes : MonoBehaviour
{
    public delegate void FlashEvent();
    public event FlashEvent Flash;

    [SerializeField]
    Image timeMeter;

    [Space, SerializeField, Header("When time is up; the display flashes\n\nSETTINGS")]
    int amountOfFlashes = 5;
    [SerializeField]
    float timeBetweenFlashes = 0.2f;
    [SerializeField]
    int setsOfFlashes = 3;
    [SerializeField]
    float timeBetweenSetsOfFlashes = 1.5f;

    void OnEnable()
    {
        transform.parent.GetComponent<TimeHandler>().TimeHitZero += EnableFlash;
    }
    void OnDisable()
    {
        transform.parent.GetComponent<TimeHandler>().TimeHitZero -= EnableFlash;
    }

    public void StopFlashing()
    {
        StopAllCoroutines();
        timeMeter.fillAmount = 0;
    }

    public void EnableFlash()
    {
        StartCoroutine(FlashRoutine());
    }

    IEnumerator FlashRoutine()
    {
        for (int i = 0; i < setsOfFlashes; i++)
        {
            for (int j = 0; j < amountOfFlashes; j++)
            {
                timeMeter.fillAmount = 1;
                Flash?.Invoke();
                yield return new WaitForSeconds(timeBetweenFlashes);
                timeMeter.fillAmount = 0;
                yield return new WaitForSeconds(timeBetweenFlashes);
            }
            yield return new WaitForSeconds(timeBetweenSetsOfFlashes);
        }
    }
}
