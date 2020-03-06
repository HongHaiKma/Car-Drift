using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;
 
public class EventManager : Singleton<EventManager>
{
 
    private Dictionary<string, UnityEvent> eventDictionary;
 
    void Init()
    {
        eventDictionary = new Dictionary<string, UnityEvent>();
    }

    public static void StartListening(string eventName, UnityAction listener)
    {
    //We need to crate place in memory for reference to the object 
        UnityEvent thisEvent = null;
        if (Instance.eventDictionary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent.AddListener(listener);
        }
        else
            {
            //If there is no event with this name add new one to dictionary.
                thisEvent = new UnityEvent();
                thisEvent.AddListener(listener);
                Instance.eventDictionary.Add(eventName, thisEvent);
            }
        }

    public static void StopListening(string eventName, UnityAction listener)
    {
        UnityEvent thisEvent = null;
        if (Instance.eventDictionary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent.RemoveListener(listener);
        }
    }

    public static void TriggerEvent(string eventName)
    {
        UnityEvent thisEvent = null;
        if (Instance.eventDictionary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent.Invoke();
        }
    }
}
