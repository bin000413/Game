using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UIManager : MonoBehaviour
{
    public PlayerStateBar PSB;
    [Header("¼àÌýÊÂ¼þ")] 
    public CharacterEventSO HealthEvent;
    public void OnEnable()
    {
        HealthEvent.OnEventRaised += OnHealthEvent;
    }
    public void OnDisable()
    {
        HealthEvent.OnEventRaised -= OnHealthEvent;
    }

    private void OnHealthEvent(character character)
    {
        var persentage = character.nowhealth / character.Maxhealth;
        Debug.Log(persentage);Debug.Log(character.nowhealth);//Debug.Log(character.Maxhealth);
        PSB.OnHealthChange(persentage);
    }

}



