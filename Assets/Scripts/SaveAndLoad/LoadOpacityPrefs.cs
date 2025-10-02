using UnityEngine;
using UnityEngine.UI;

public class LoadOpacityPrefs : MonoBehaviour
{
    Slider slider;

    [SerializeField]
    BorderlessWindow borderlessWindow;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        slider = GetComponent<Slider>();
        float savedOpacity = PlayerPrefs.GetFloat("InactiveOpacity", 0.5f);
        slider.value = savedOpacity;
        borderlessWindow.InactiveOpacity = savedOpacity;
    }
}
