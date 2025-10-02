using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class LoadVolumeValue : MonoBehaviour
{
    [SerializeField]
    Slider slider;

    [SerializeField]
    ChangeSpriteOnValue changeSpriteOnValue;

    [SerializeField]
    AudioMixer audioMixer;

    bool doneOnce = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (doneOnce) return;
        doneOnce = true;

        if (PlayerPrefs.HasKey("Volume"))
        {
            float volume = PlayerPrefs.GetFloat("Volume");
            slider.value = volume;
            changeSpriteOnValue.ChangeSprite(volume);
            audioMixer.SetFloat("Volume", volume);
        }        
    }
}
