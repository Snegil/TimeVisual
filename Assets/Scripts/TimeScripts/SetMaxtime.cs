using UnityEngine;

public class SetMaxtime : MonoBehaviour
{
    [SerializeField]
    TimeDisplayManager timeDisplayManager;

    [Space, SerializeField]
    int maxTime;

    void OnEnable()
    {
        timeDisplayManager.MaxTime = maxTime;
    }
}
