using UnityEngine;

public class EnableBox : MonoBehaviour
{
    TimeHandler timeHandler;

    [SerializeField]
    GameObject boxToEnable;

    void Awake()
    {
        timeHandler = GameObject.FindGameObjectWithTag("TimeHandler").GetComponent<TimeHandler>();
    }

    private void OnEnable()
    {
        timeHandler.TimeHitZero += Enable;
    }
    private void OnDisable()
    {
        timeHandler.TimeHitZero -= Enable;
    }
    public void Enable()
    {
        boxToEnable.SetActive(true);
    }
}
