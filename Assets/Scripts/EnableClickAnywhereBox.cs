using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableClickAnywhereBox : MonoBehaviour
{
    [SerializeField]
    TimeHandler timeHandler;

    [SerializeField]
    GameObject clickAnywhereBox;

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
        clickAnywhereBox.SetActive(true);
    }
}
