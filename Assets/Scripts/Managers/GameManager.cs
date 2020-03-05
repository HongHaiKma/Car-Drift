using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance
    { get { if (instance == null) instance = GameObject.FindObjectOfType<GameManager>(); return instance; } }

    public List<GameObject> carPool;
    public List<CarController> carControllerPool;
    public GameObject car;

    public bool lose = false;

    void Awake()
    {
        CreateCarPool();

        ActiveCar();
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

    public void ActiveCar()
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
        ActiveCar();
    }
}
