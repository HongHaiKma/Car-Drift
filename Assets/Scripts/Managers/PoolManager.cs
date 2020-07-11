using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : Singleton<PoolManager>
{
    [Header("Car")]
    public List<CarController> carControllerPool;
    public CarController car;

    [Header("Checkpoint")]
    public List<Transform> cpTf;

    [Header("Checkpoint")]
    public int maxCar;

    void Awake()
    {
        CreateCarPool();

        ActivateNewCar();
    }

    public void CreateCarPool()
    {
        maxCar = 12;

        for (int i = 0; i < maxCar; i++)
        {
            carControllerPool.Add(Instantiate(car));
            // CarEvent.Instance.StopDrift();
            carControllerPool[i].SetActiveGO(false);
        }
    }

    public void ActivateNewCar()
    {
        GameManager.Instance.gameStart = true;

        for (int i = 0; i < carControllerPool.Count; i++)
        {
            if (!carControllerPool[i].IsActive())
            {
                carControllerPool[i].SetActiveGO(true);
                carControllerPool[i].carMotion.tf.position = new Vector3(0f, 0f, 0f);
                TopDownCamera.Instance.curCarTf = carControllerPool[i].carMotion.tf;
                TopDownCamera.Instance.curCarRb = carControllerPool[i].carMotion.rb;
                // CarEvent.Instance.MoveForward();
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

    public bool PickNearestTarget(Vector3 carPos)
    {
        float distance = Mathf.Infinity;
        int nearestIdx = -1;

        for (int i = 0; i < cpTf.Count; i++)
        {
            if (carPos.z < cpTf[i].position.z)
            {
                Vector2 origin = new Vector2(carPos.x, carPos.z);
                Vector2 des = new Vector2(cpTf[i].position.x, cpTf[i].position.z);

                float tempDistance = VectorTool.CalDistance(origin, des);

                if (distance > tempDistance)
                {
                    distance = tempDistance;
                    nearestIdx = i;
                }
            }
        }

        if (cpTf[nearestIdx].position.x < carPos.x)
        {
            Debug.Log("Nearest index: " + nearestIdx);
            Debug.Log("Check point: " + cpTf[nearestIdx].position.x);
            Debug.Log("Car: " + carPos.x);
            return true;
        }
        else
        {
            Debug.Log("Nearest index: " + nearestIdx);
            Debug.Log("Check point: " + cpTf[nearestIdx].position.x);
            Debug.Log("Car: " + carPos.x);
            return false;
        }
    }

    public float CalculateDistance(Vector2 origin, Vector2 des)
    {
        return Vector2.Distance(origin, des);
    }

    public float CalculateDistance(Vector3 origin, Vector3 des)
    {
        return Vector3.Distance(origin, des);
    }

    public void ResetGame()
    {
        GameManager.Instance.gameStart = true;
        DeactiveCar();
        ActivateNewCar();
    }
}
