using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListTool : MonoBehaviour
{
    public static float GetMaxvalue(List<float> target)
    {
        target.Sort((p1, p2) => p1.CompareTo(p2));

        return target[0];
    }
}
