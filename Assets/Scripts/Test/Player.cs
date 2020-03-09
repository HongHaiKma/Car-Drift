using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            CheckEnemyDie();
        }
    }

    void CheckEnemyDie()
    {
        
    }
}
