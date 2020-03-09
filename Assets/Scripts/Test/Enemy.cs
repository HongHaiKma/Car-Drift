using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Collider col;

    // void Start()
    // {
    //     col = GetComponent<Collider>();

    //     Debug.Log(col.bounds.max);
    //     Debug.Log(col.bounds.min);
    // }

    private bool die;

    private void Awake()
    {
        die = false;    
    }

    void OnEnable()
    {
        // EventManager.StartListening("test", SubscribedAction);
        EventManager.StartListening("CheckDie", CheckDie);
    }
    
    void OnDisable()
    {
        // EventManager.StopListening("test", SubscribedAction);
        EventManager.StopListening("CheckDie", CheckDie);
    }

    void SubscribedAction()
    {
        Debug.Log("Alloooooooo");
    }

    void CheckDie()
    {

    }
}
