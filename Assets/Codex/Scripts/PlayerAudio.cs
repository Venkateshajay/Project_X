using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    public float speed;
    [SerializeField] AudioClip[] audioClips;
    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if(speed > 3)
        {
            audioSource.clip = audioClips[1];
            audioSource.Play();
        }else if (speed == 0)
        {
            audioSource.Stop();
        }
    }
}
