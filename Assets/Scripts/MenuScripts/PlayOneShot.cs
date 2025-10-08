using UnityEngine;

public class PlayOneShot : MonoBehaviour
{
    [SerializeField]
    AudioSource audioSource;

    public void OneShotSound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
}
