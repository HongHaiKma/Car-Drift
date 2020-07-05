using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomTool : MonoBehaviour
{
    public static bool Random2Probability(int percent)
    {
        int pickPercent = Random.Range(1, 101);

        if (pickPercent <= percent)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
