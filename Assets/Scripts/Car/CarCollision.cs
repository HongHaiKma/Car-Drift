using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarCollision : MonoBehaviour
{
    public CarMotion carMotion;
    public bool parked;

    private void Awake()
    {
        carMotion = GetComponent<CarMotion>();
    }

    private void OnEnable()
    {
        ResetCollisionStatus();
    }

    public void ResetCollisionStatus()
    {
        parked = false;
    }

    public void CheckParking()
    {
        if (parked)
        {
            PoolManager.Instance.ActivateNewCar();
            Debug.Log("Parked!!!!!");
        }
        else
        {
            GameManager.Instance.StopGame();
            Debug.Log("Not Parked!!!!!");
        }
    }

    void OnTriggerEnter(Collider col)
    {
        Debug.Log("Trigger enter!!!");

        Debug.Log(col.name);

        if (carMotion.CompareState(CarState.StopDrifting))
        {
            // Debug.Log(col.name);

            if (col.GetComponents<ParkingPoint>() != null)
            {
                //Calculate percentage of collision --->>> Last
                //if percentage < x => lose
                //if percentage >= x => continue

                // GameManager.Instance.gameStart = true;
                parked = true;
                Debug.Log("Check point!!!");
            }

            // CheckParking();
        }
    }
}
