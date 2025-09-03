using UnityEngine;

public class DisableIfNotOnHandheld : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (SystemInfo.deviceType == DeviceType.Handheld){ return; }
        
        gameObject.SetActive(false);
    }
}
