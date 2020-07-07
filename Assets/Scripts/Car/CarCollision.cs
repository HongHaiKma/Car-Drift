using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarCollision : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        GameManager.Instance.Continue();
    }
}
