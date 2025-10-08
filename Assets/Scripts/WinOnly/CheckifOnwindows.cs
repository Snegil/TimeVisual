using UnityEngine;

public class CheckifOnwindows : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (SystemInfo.deviceType == DeviceType.Handheld || Application.isEditor)
        {
            return;
        }   
        
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(true);
        }
    }
}
