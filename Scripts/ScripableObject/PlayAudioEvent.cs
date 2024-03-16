using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName ="Event/PlayAudioEvent")]
public class PlayAudioEvent : ScriptableObject
{
    public UnityAction<AudioClip> OneventRaised; 
    public void RaiseEvent(AudioClip audioclip)
    {
        OneventRaised?.Invoke(audioclip);
    }
}
