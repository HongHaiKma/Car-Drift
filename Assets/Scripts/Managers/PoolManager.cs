using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

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
    }

    public void CreateCarPool()
    {
        maxCar = 12;

        for (int i = 0; i < maxCar; i++)
        {
            carControllerPool.Add(Instantiate(car));
            carControllerPool[i].SetActiveGO(false);
        }
    }

    public void ActivateNewCar()
    {
        GameManager.Instance.gameStart = true;

        // GameObject[] a = new GameObject[2];

        if (carControllerPool.All(obj => obj.IsActive() == true))
        {
            CarEvent.Instance.Disabled(false);
        }

        for (int i = 0; i < carControllerPool.Count; i++)
        {
            if (!carControllerPool[i].IsActive())
            {
                carControllerPool[i].SetCarSpawn();
                TopDownCamera.Instance.curCarTf = carControllerPool[i].carMotion.tf;
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
            if (carPos.z < cpTf[i].position.z) // ===> determine before or after by z axis
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
            return true;
        }
        else
        {
            return false;
        }

        // if (cpTf[nearestIdx].position.x < carPos.x)
        // {
        //     if (spd == Speed.Spd1)
        //     {
        //         return true;
        //     }
        //     else if (spd == Speed.Spd2)
        //     {
        //         return (cpTf[nearestIdx].position.z - carPos.z) <= 10f ? false : true;
        //     }
        //     else if (spd == Speed.Spd3)
        //     {
        //         return (cpTf[nearestIdx].position.z - carPos.z) <= 14 ? false : true;
        //     }
        // }
        // else if (cpTf[nearestIdx].position.x < carPos.x && spd == Speed.Spd2)
        // {
        //     if ((cpTf[nearestIdx].position.z - carPos.z) <= 10f)
        //     {
        //         return false;
        //     }
        //     else
        //     {
        //         return true;
        //     }
        // }
        // else if (cpTf[nearestIdx].position.x < carPos.x && spd == Speed.Spd3)
        // {
        //     if ((cpTf[nearestIdx].position.z - carPos.z) <= 14f)
        //     {
        //         return false;
        //     }
        //     else
        //     {
        //         return true;
        //     }
        // }

        // if (cpTf[nearestIdx].position.x >= carPos.x && spd == Speed.Spd1)
        // {
        //     return true;
        // }
        // else if (cpTf[nearestIdx].position.x >= carPos.x && spd == Speed.Spd2)
        // {
        //     if ((cpTf[nearestIdx].position.z - carPos.z) <= 10f)
        //     {
        //         return false;
        //     }
        //     else
        //     {
        //         return true;
        //     }
        // }
        // else if (cpTf[nearestIdx].position.x >= carPos.x && spd == Speed.Spd3)
        // {
        //     if ((cpTf[nearestIdx].position.z - carPos.z) <= 14f)
        //     {
        //         return false;
        //     }
        //     else
        //     {
        //         return true;
        //     }
        // }
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
        // ActivateNewCar();
    }

    public void ClickTest()
    {
        CarEvent.Instance.Test();
    }
}
