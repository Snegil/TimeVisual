using UnityEngine;

public class SetMaxTimeOnEnable : MonoBehaviour
{
    [Space, SerializeField, Header("TimeDisplay Script")]
    TimeDisplayManager timeDisplayManager;

    TimeHandler timeHandler;

    [Space, SerializeField, Header("Max Time in MINUTES")]
    float maxTime;

    void Awake()
    {
        timeHandler = GameObject.FindGameObjectWithTag("TimeHandler").GetComponent<TimeHandler>();
    }
    
    private void OnEnable()
    {
        timeDisplayManager.TimeMaximum(maxTime);
        timeHandler.ResetTime();
    }
}
