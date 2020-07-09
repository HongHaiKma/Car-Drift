using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public List<GameObject> carPool;
    public List<CarController> carControllerPool;
    public GameObject car;

    public bool gameStart = false;

    public void Continue()
    {
        gameStart = true;
    }
}
