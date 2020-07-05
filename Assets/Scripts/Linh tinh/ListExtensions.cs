using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ListExtensions
{
    public static void AddMany<T>(this List<T> list, params T[] elements)
    {
        list.AddRange(elements);
    }
}
