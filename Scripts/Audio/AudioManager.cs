using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public AudioSource BGMAudioSource;
    public AudioSource FXAudioSource;
    public PlayAudioEvent FXEvent;
    public PlayAudioEvent BGMEvent;
    private void OnEnable()
    {
        FXEvent.OneventRaised += OnFXEvent;
        BGMEvent.OneventRaised += OnBGMEvent;
    }

    private void OnDisable()
    {
        FXEvent.OneventRaised -= OnFXEvent;
        BGMEvent.OneventRaised -= OnBGMEvent;
    }

    private void OnFXEvent(AudioClip clip)
    {
        FXAudioSource.clip = clip;
        FXAudioSource.Play();
    }
    private void OnBGMEvent(AudioClip clip)
    {
        BGMAudioSource.clip = clip;
        BGMAudioSource.Play();
    }


}
