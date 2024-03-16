using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
[CreateAssetMenu(menuName = "Event/CharacterEventSO")]
public class CharacterEventSO : ScriptableObject
{
    public UnityAction<character> OnEventRaised;
    public void RaisedEvent(character character)
    {
        OnEventRaised?.Invoke(character);
    }
}
