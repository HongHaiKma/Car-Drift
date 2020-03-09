﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test2 : MonoBehaviour
{
    // Collider col;

    // void Start()
    // {
    //     col = GetComponent<Collider>();

    //     Debug.Log(col.bounds.max);
    //     Debug.Log(col.bounds.min);
    // }

    void OnEnable()
    {
        EventManager.StartListening("test", SubscribedAction);
    }
    
    void OnDisable()
    {
        EventManager.StopListening("test", SubscribedAction);
    }

    void SubscribedAction()
    {
        Debug.Log("Alloooooooo");
    }

    void Update()
    {
        // Debug.Log(col.bounds.max);
        // Debug.Log(col.bounds.min);
        // Debug.Log("aaaa");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            EventManager.TriggerEvent("test");
        }
    }
}
