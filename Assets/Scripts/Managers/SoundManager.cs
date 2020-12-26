﻿using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    [HideInInspector]
    public AudioSource audioSource;
    private float currentVolume = 1f;
    public float CurrentVolume { get => isMuted ? 0 : currentVolume; set => currentVolume = value; }

    public AudioClip buttonClickSfx;
    public bool isMuted = false;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();

        audioSource.mute = isMuted;
    }

    void Start()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void PlaySound2D(AudioClip audio)
    {
        audioSource.PlayOneShot(audio, CurrentVolume);
    }

    public void PlayButtonSfx()    
    {
        if(buttonClickSfx != null)
            PlaySound2D(buttonClickSfx);
    }

    public void Mute(bool mute)
    {
        audioSource.mute = mute;
        instance.isMuted = mute;
    }
}
