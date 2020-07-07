using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    [Header("Components")]
    public CarMotion carMotion;
    public Quaternion targetRotation;

    void Awake()
    {
        CacheComponents();
    }

    public void CacheComponents()
    {
        carMotion = GetComponent<CarMotion>();
    }

    public void Update()
    {
        if (Input.GetKeyUp("a"))
        {
            carMotion.StopCarMotion();

            if (!GameManager.Instance.gameEnd)
            {
                StartCoroutine(CreateNewCar());
            }
        }
        else if (Input.GetKeyUp("d"))
        {
            carMotion.StopCarMotion();

            if (!GameManager.Instance.gameEnd)
            {
                StartCoroutine(CreateNewCar());
            }
        }

        carMotion.SetSideSlip();
    }

    public void FixedUpdate()
    {
        Rotate();
        Drift();
    }

    public void Rotate()
    {
        if (Input.GetKey("a"))
        {
            carMotion.RotateLeft();
        }
        else if (Input.GetKey("d"))
        {
            carMotion.RotateRight();
        }
    }

    public void Drift()
    {
        if (carMotion.drift)
        {
            if (Input.GetKey("a"))
            {
                carMotion.DriftLeft();
            }
            else if (Input.GetKey("d"))
            {
                carMotion.DriftRight();
            }
        }
        else
        {
            carMotion.KeepMovingForward();
        }
    }

    public IEnumerator CreateNewCar()
    {
        yield return new WaitForSeconds(1f);
        PoolManager.Instance.ActiveNewCar();
        SetActiveGO(false);
    }

    public void SetActiveGO(bool status)
    {
        gameObject.SetActive(status);
    }

    public bool IsActive()
    {
        return gameObject.activeInHierarchy;
    }

    // public void SetRotationPoint()
    // {
    //     Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    //     Plane plane = new Plane(Vector3.up, Vector3.zero);
    //     float distance;

    //     if (plane.Raycast(ray, out distance))
    //     {
    //         Vector3 target = ray.GetPoint(distance);
    //         Vector3 direction = target - tf.position;

    //         float rotationAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
    //         targetRotation = Quaternion.Euler(0, rotationAngle, 0);
    //     }
    // }
}
