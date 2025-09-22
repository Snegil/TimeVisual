using UnityEngine;
using UnityEngine.EventSystems;

public class ClearSelected : MonoBehaviour
{
    [SerializeField]
    float timer = 5f;
    float setTimer;

    void Start()
    {
        setTimer = timer;
    }
    // Update is called once per frame
    void Update()
    {
        if (EventSystem.current.currentSelectedGameObject == null) return;
        
        timer -= Time.deltaTime;

        if (timer !<= 0) return;

        timer = setTimer;

        EventSystem.current.SetSelectedGameObject(null);
    }
}
