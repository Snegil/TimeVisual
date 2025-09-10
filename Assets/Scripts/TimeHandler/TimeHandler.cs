using UnityEngine;

public class TimeHandler : MonoBehaviour
{
    public delegate void TimeHitZeroEvent();
    public delegate void TimeChangedEvent(float time);
    public event TimeChangedEvent TimeChanged;
    public event TimeHitZeroEvent TimeHitZero;

    //public Action<float> TimeChanged; exempel p� "prefab" f�r delegates
    [SerializeField]
    float timeRemaining;

    bool tick;

    // Start is called before the first frame update
    void Start()
    {
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
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            TimeChanged?.Invoke(timeRemaining);
            if (timeRemaining <= 0)
            {
                TimeHitZero?.Invoke();
                tick = false;
            }
        }
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