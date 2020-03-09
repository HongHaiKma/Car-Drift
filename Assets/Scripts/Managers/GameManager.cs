using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public List<GameObject> carPool;
    public List<CarController> carControllerPool;
    public GameObject car;

    public bool lose = false;

    void Awake()
    {
        CreateCarPool();

        ActiveNewCar();
    }

    void OnEnable()
    {
        EventManager.StartListening(GameEvent.GameContinue, Lose);
        EventManager.StartListening(GameEvent.ActiveNewCar, ActiveNewCar);
    }

    public void Lose()
    {
        lose = false;
    }

    public void CreateCarPool()
    {
        for (int i = 0; i < 10; i++)
        {
            carPool.Add(Instantiate(car));
            carControllerPool.Add(carPool[i].GetComponent<CarController>());
            carControllerPool[i].SetActiveGO(false);
        }
    }

    public void ActiveNewCar()
    {
        lose = true;
        for (int i = 0; i < carPool.Count; i++)
        {
            if(!carPool[i].gameObject.activeInHierarchy)
            {
                carControllerPool[i].SetActiveGO(true);
                TopDownCamera.Instance.curCarTf = carControllerPool[i].tf;
                TopDownCamera.Instance.curCarRb = carControllerPool[i].rb;
                break;
            }
        }
    }

    public void DeactiveCar()
    {
        for (int i = 0; i < carPool.Count; i++)
        {
            carControllerPool[i].SetActiveGO(false);
        }
    }

    public void ResetGame()
    {
        lose = false;
        DeactiveCar();
        ActiveNewCar();
    }
}
