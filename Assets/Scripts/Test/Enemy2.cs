using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{
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
