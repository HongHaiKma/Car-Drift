using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParkArea : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Check point");
    }
}
