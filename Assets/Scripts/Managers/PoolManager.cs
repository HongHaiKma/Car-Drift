using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : Singleton<PoolManager>
{
    [Header("Car")]
    public List<CarController> carControllerPool;
    public CarController car;

    // [Header("Checkpoint")]

    void Awake()
    {
        CreateCarPool();

        ActiveNewCar();
    }

    public void CreateCarPool()
    {
        for (int i = 0; i < 10; i++)
        {
            carControllerPool.Add(Instantiate(car));
            carControllerPool[i].SetActiveGO(false);
        }
    }

    public void ActiveNewCar()
    {
        GameManager.Instance.gameStart = true;

        for (int i = 0; i < carControllerPool.Count; i++)
        {
            if (!carControllerPool[i].IsActive())
            {
                carControllerPool[i].SetActiveGO(true);
                TopDownCamera.Instance.curCarTf = carControllerPool[i].carMotion.tf;
                TopDownCamera.Instance.curCarRb = carControllerPool[i].carMotion.rb;
                break;
            }
        }
    }

    public void DeactiveCar()
    {
        for (int i = 0; i < carControllerPool.Count; i++)
        {
            carControllerPool[i].SetActiveGO(false);
        }
    }

    public void ResetGame()
    {
        GameManager.Instance.gameStart = true;
        DeactiveCar();
        ActiveNewCar();
    }
}
