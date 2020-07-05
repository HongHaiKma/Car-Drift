using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarCollision : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        // EventManager.TriggerEvent(GameEvent.GameContinue);
        GameManager.Instance.Continue();
        Debug.Log("Car collide!!!");
    }
}
