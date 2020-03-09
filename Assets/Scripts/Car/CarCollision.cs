using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarCollision : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        EventManager.TriggerEvent(GameEvent.GameContinue);
    }
}
