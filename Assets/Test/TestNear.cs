using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestNear : MonoBehaviour
{
    public Transform tf;
    public List<Transform> cpTf;

    void Awake()
    {
        tf = GetComponent<Transform>();

        PickNearestTarget();
    }

    public void PickNearestTarget()
    {
        float distance = Mathf.Infinity;
        int nearestIdx = -1;

        for (int i = 0; i < cpTf.Count; i++)
        {
            if (tf.position.z < cpTf[i].position.z)
            {
                Debug.Log(cpTf[i].name);

                Vector2 origin = new Vector2(tf.position.x, tf.position.z);
                Vector2 des = new Vector2(cpTf[i].position.x, cpTf[i].position.z);

                float tempDistance = VectorTool.CalDistance(origin, des);

                if (distance > tempDistance)
                {
                    distance = tempDistance;
                    nearestIdx = i;
                }

                // Debug.Log("1: " + CalDistance(origin, des));
                // Debug.Log("2: " + CalDistance2(origin, des));
            }
        }

        Debug.Log("Nearest go name: " + cpTf[nearestIdx]);
        Debug.Log("Nearest go index: " + nearestIdx);
        Debug.Log("Nearest go distance: " + distance);

        if (cpTf[nearestIdx].position.x < tf.position.x)
        {
            Debug.Log("Nearest on the left");
        }
        else
        {
            Debug.Log("Nearest on the right");
        }
    }
}
