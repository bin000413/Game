using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Event/ViodEventSO")]
public class VoidEventSO : ScriptableObject
{
    public UnityAction OneventRaised;
    public void RaiseEvet()
    {
        OneventRaised?.Invoke();
    }
}
