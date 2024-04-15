using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    AudioClips audioclips;
    AudioClip audioToPlay;
    AudioSource audioSource;

    private void Awake()
    {
        instance = this;
        audioclips = GetComponent<AudioClips>();
        audioSource = GetComponent<AudioSource>();
        ChangeAudioClip(0);
        Play();
    }

    public void ChangeAudioClip(int index)
    {
        audioToPlay = audioclips.audioclips[index];
        audioSource.clip = audioToPlay;
    }

    public void Play()
    {
        audioSource.Play();   
    }
    public void Pause()
    {
        audioSource.Pause();
    }

    public void Stop()
    {
        audioSource.clip = null;
        audioSource.Pause();
    }
}
