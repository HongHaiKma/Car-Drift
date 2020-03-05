using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test2 : MonoBehaviour
{
    Collider col;

    void Start()
    {
        col = GetComponent<Collider>();

        Debug.Log(col.bounds.max);
        Debug.Log(col.bounds.min);
    }

    void Update()
    {
        Debug.Log(col.bounds.max);
        Debug.Log(col.bounds.min);
    }
}
