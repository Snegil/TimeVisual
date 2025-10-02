using UnityEngine;
using UnityEngine.UI;

public class SaveOpacityPrefs : MonoBehaviour
{
    Slider slider;

    void Start()
    {
        slider = GetComponent<Slider>();
    }
    public void SaveOpacityPreference()
    {
        PlayerPrefs.SetFloat("InactiveOpacity", slider.value);
    }
}
