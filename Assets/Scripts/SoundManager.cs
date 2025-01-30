using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;
    public AudioSource BackgroundAudioSource;
    public AudioSource soundFXAudioSource;
    //public AudioClip levelCompleteAudio;
    //public AudioClip gameOverAudio;
    public AudioClip buttonClick;


    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        playbackgoundMusic();
    }

    public void playbackgoundMusic()
    {
        if (BackgroundAudioSource != null && BackgroundAudioSource.clip != null && !BackgroundAudioSource.isPlaying)
        {
            BackgroundAudioSource.Play();
        }

    }

    internal void PlayButtonClickAudio()
    {
        if (soundFXAudioSource != null && buttonClick != null)
        {
            soundFXAudioSource.PlayOneShot(buttonClick);
        }
    }
   
}
