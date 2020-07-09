using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public List<GameObject> carPool;
    public List<CarController> carControllerPool;
    public GameObject car;

    public bool gameStart = false;

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    Debug.Log("Touch began!!!");
                    break;

                case TouchPhase.Moved:
                    break;

                case TouchPhase.Ended:
                    Debug.Log("Touch ended!!!");
                    break;
            }
        }
    }

    public void Continue()
    {
        gameStart = true;
    }
}
