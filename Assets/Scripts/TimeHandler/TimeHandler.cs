using UnityEngine;

public class TimeHandler : MonoBehaviour
{
    public delegate void TimeHitZeroEvent();
    public delegate void TimeChangedEvent(float time);
    public event TimeChangedEvent TimeChanged;
    public event TimeHitZeroEvent TimeHitZero;

    [SerializeField]
    float timeRemaining;

    bool tick;

    float secondHasPassed = 1f;
    float setSecondHasPassed;

    void Start()
    {
        setSecondHasPassed = secondHasPassed;
    }

    // Update is called once per frame
    void Update()
    {
        if (tick == true)
        {
            TickDown();
        }
    }

    void TickDown()
    {
        if (timeRemaining <= 0) return;

        timeRemaining -= Time.deltaTime;
        secondHasPassed -= Time.deltaTime;

        if (secondHasPassed < 0)
        {
            Debug.Log("Tick");
            secondHasPassed += setSecondHasPassed;
            TimeChanged?.Invoke(timeRemaining);
        }
        

        if (timeRemaining <= 0)
        {
            TimeHitZero?.Invoke();
            tick = false;
        }
    }
    public void UpdateTimeMeter()
    {
        TimeChanged?.Invoke(timeRemaining);
    }
    public void SetTime(int time)
    {
        //TODO: FIX VIBRATION ON PHONES
        //Handheld.Vibrate();
        timeRemaining = time;
        tick = true;
    }
    public void ResetTime()
    {
        timeRemaining = 0;
        TimeChanged?.Invoke(timeRemaining);
        tick = false;
    }
}