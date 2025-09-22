using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TimeFlashes : MonoBehaviour
{   
    Image image;

    [Space, SerializeField, Header("When time is up; the display flashes\n\nSETTINGS")]
    int amountOfFlashes = 5;
    [SerializeField]
    float timeBetweenFlashes = 0.2f;
    [SerializeField]
    int setsOfFlashes = 3;
    [SerializeField]
    float timeBetweenSetsOfFlashes = 1.5f;
    
    [SerializeField]
    AudioClip flashSound;
    [SerializeField]
    AudioSource audioSource;

    TimeHandler timeHandler;

    void Awake()
    {
        timeHandler = GameObject.FindGameObjectWithTag("TimeHandler").GetComponent<TimeHandler>();
        image = GetComponent<Image>();
    }

    void OnEnable()
    {
        timeHandler.TimeHitZero += Flash;
    }
    void OnDisable()
    {
        timeHandler.TimeHitZero -= Flash;
    }

    public void StopFlashing()
    {
        StopAllCoroutines();
        image.fillAmount = 0;
    }
    public void Flash()
    {
        StartCoroutine(FlashRoutine());
    }
    IEnumerator FlashRoutine()
    {
        for (int i = 0; i < setsOfFlashes; i++)
        {
            for (int j = 0; j < amountOfFlashes; j++)
            {
                image.fillAmount = 1;
                audioSource.pitch = j % 2 == 0 ? 0.99f : 1.01f;
                audioSource.PlayOneShot(flashSound);
                yield return new WaitForSeconds(timeBetweenFlashes);
                image.fillAmount = 0;
                yield return new WaitForSeconds(timeBetweenFlashes);
            }
            yield return new WaitForSeconds(timeBetweenSetsOfFlashes);
        }
    }
}
