using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;
 
public class EventManager : Singleton<EventManager>
{
    private Dictionary<string, UnityEvent> evtDict;

    private void Awake()
    {
        Init();
    }

    void Init()
    {
        evtDict = new Dictionary<string, UnityEvent>();
    }

    public static void StartListening(string eventName, UnityAction listener)
    {
        UnityEvent thisEvent = null;
        if (Instance.evtDict.TryGetValue(eventName, out thisEvent))
        {
            thisEvent.AddListener(listener);
        }
        else
        {
            thisEvent = new UnityEvent();
            thisEvent.AddListener(listener);
            Instance.evtDict.Add(eventName, thisEvent);
        }
    }

    public static void StopListening(string eventName, UnityAction listener)
    {
        UnityEvent thisEvent = null;
        if (Instance.evtDict.TryGetValue(eventName, out thisEvent))
        {
            thisEvent.RemoveListener(listener);
        }
    }

    public static void TriggerEvent(string eventName)
    {
        UnityEvent thisEvent = null;
        if (Instance.evtDict.TryGetValue(eventName, out thisEvent))
        {
            thisEvent.Invoke();
        }
    }
}
