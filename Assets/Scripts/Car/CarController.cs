using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    [Header("General")]
    public CollideObject collideObject;

    [Header("Components")]
    public CarMotion carMotion;
    public Quaternion targetRotation;

    [Header("State")]
    public StateMachine stateMachine;
    public CarStateInstance carStateInstance;

    void Awake()
    {
        CacheComponents();
        InitStateMachine();
    }

    public void CacheComponents()
    {
        carMotion = GetComponent<CarMotion>();
    }

    void OnEnable()
    {
        carMotion.SetupNewCarStatus();
        StartListenToEvent();
        // stateMachine.ChangeState(carStateInstance.moveForward);
    }

    void OnDisable()
    {
        StartListenToEvent();
    }

    public void InitStateMachine()
    {
        carStateInstance = new CarStateInstance();
        stateMachine = new StateMachine(this.carMotion);
        stateMachine.Init(carStateInstance.idleState);
        // stateMachine.Init(carStateInstance.moveForward);
    }

    public void StartListenToEvent()
    {
        CarEvent.Instance.OnDrift += OnDrift;
        CarEvent.Instance.OnStopDrift += OnStopDrift;
        CarEvent.Instance.OnSpawnNewCar += OnSpawnNewCar;
        CarEvent.Instance.OnTest += Test;
    }

    public void StopListenToEvent()
    {
        CarEvent.Instance.OnDrift -= OnDrift;
        CarEvent.Instance.OnStopDrift -= OnStopDrift;
        CarEvent.Instance.OnSpawnNewCar -= OnSpawnNewCar;
        CarEvent.Instance.OnTest += Test;
    }

    public void FixedUpdate()
    {
        stateMachine.ExecuteStateUpdate();
    }

    public void Drift()
    {

    }

    public void OnSpawnNewCar()
    {
        // StartCoroutine(IESpawnNewCar());
        Invoke("IESpawnNewCar", 1f);
    }

    public void IESpawnNewCar()
    {
        // PoolManager.Instance.ActiveNewCar();
        // yield return new WaitForSeconds(1f);
        UIManager.Instance.btn_Drift.interactable = true;
        PoolManager.Instance.ActivateNewCar();
        // SetActiveGO(false);
        Debug.Log("IE spwan a new car called!!!");
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

    //-------------------------------------EVENTS-------------------------------------------

    public void OnDrift()
    {
        if (IsActive() && !carMotion.CompareState(CarState.Drifting))
        {
            stateMachine.ChangeState(carStateInstance.driftState);
        }
    }

    public void OnStopDrift()
    {
        if (IsActive() && !carMotion.CompareState(CarState.StopDrifting))
        {
            stateMachine.ChangeState(carStateInstance.stopDriftState);
        }
    }

    public void Test()
    {
        Debug.Log("Testtttt!!");
    }
}
