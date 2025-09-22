using UnityEngine;
using UnityEngine.Audio;

public class ChangeVolumeOnValue : MonoBehaviour
{
    [SerializeField]
    AudioMixer audioMixer;
    [SerializeField]
    AudioSource audioSource;

    public void ChangeVolume(float value)
    {
        if (value <= -39f)
        {
            audioSource.mute = true;
            return;
        }
        audioSource.mute = false;
        audioMixer.SetFloat("Volume", value);
    }
}
