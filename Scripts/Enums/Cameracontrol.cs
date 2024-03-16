using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using Unity.VisualScripting;
using System;

public class Cameracontrol : MonoBehaviour
{
    public CinemachineImpulseSource CIS;
    private CinemachineConfiner2D CCD;
    [Header("¼àÌýÊÂ¼þ")]
    public VoidEventSO VoidEventSO;
    private void OnEnable()
    {
        VoidEventSO.OneventRaised += OnShark;
    }
    private void OnDisable()
    {
        VoidEventSO.OneventRaised -= OnShark;
    }

    private void OnShark()
    {
        CIS.GenerateImpulse();
    }

    private void Awake()
    {
        CCD = GetComponent<CinemachineConfiner2D>();
    }
    private void Start()
    {
        GetCamerBound();
    }
    public void GetCamerBound()
    {
        var obj = GameObject.FindGameObjectWithTag("Bound");
        if (obj == null)
            return;
        //Debug.Log("dizhi");
        CCD.m_BoundingShape2D = obj.GetComponent<Collider2D>();
        CCD.InvalidateCache();
    }
 }
