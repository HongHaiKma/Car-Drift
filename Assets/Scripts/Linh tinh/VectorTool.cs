using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorTool : MonoBehaviour
{
    public static float CalDistance(Vector2 origin, Vector2 des)
    {
        return Vector2.Distance(origin, des);
    }

    public static float CalDistance(Vector3 origin, Vector3 des)
    {
        return Vector3.Distance(origin, des);
    }

    public float CalDistance2(Vector2 origin, Vector2 des)
    {
        return (origin - des).magnitude;
    }

    public float CalDistance2(Vector3 origin, Vector3 des)
    {
        return Vector3.Distance(origin, des);
    }
}
