using UnityEngine;
using UnityEngine.Audio;

public class SaveVolumePrefs : MonoBehaviour
{
    [SerializeField]
    AudioMixer audioMixer;

    public void SaveVolume()
    {
        if (audioMixer.GetFloat("Volume", out float value))
        {
            PlayerPrefs.SetInt("Volume", (int)value);
            PlayerPrefs.Save();
        }
    }
}
