using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioDefination : MonoBehaviour
{
    public PlayAudioEvent PlayAudioEvent;
    public AudioClip Clip;
    public bool playOnEnable;
    private void OnEnable()
    {
        if(playOnEnable)
        {
            PalyAudio();
        }
    }
    public void PalyAudio()
    {
        PlayAudioEvent.OneventRaised(Clip);
    }
}
