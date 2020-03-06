using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EventSubscriber : MonoBehaviour
{
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
        Color color = new Vector4(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f),1f);
    }
    void Updade()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            EventManager.TriggerEvent("test");
    }
}