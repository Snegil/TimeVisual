using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class TimeNoise : MonoBehaviour
{
    AudioSource audioSource;
    [SerializeField]
    AudioClip clip;

    bool alternatePitch = false;

    void OnEnable()
    {
        transform.parent.GetComponent<TimeFlashes>().Flash += PlayAudio;
    }
    void OnDisable()
    {
        transform.parent.GetComponent<TimeFlashes>().Flash -= PlayAudio;        
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayAudio()
    {
        audioSource.pitch = alternatePitch ? 0.99f : 1.01f;
        alternatePitch = !alternatePitch;
        
        audioSource.PlayOneShot(clip);        
    }
}
