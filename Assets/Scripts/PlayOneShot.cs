using UnityEngine;

public class PlayOneShot : MonoBehaviour
{
    [SerializeField]
    AudioSource audioSource;
    [SerializeField]
    AudioClip clip;

    public void PlayClip()
    {        
        audioSource.PlayOneShot(clip);
    }
}
