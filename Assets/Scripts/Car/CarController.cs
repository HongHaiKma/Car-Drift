using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    [Header("General")]
    public CollideObject collideObject;

    [Header("Components")]
    public CarMotion carMotion;

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
    }

    public void StartListenToEvent()
    {
        CarEvent.Instance.OnDrift += OnDrift;
        CarEvent.Instance.OnStopDrift += OnStopDrift;
        CarEvent.Instance.OnSpawnNewCar += OnSpawnNewCar;
        CarEvent.Instance.OnDisabled += SetActiveGO;
    }

    public void StopListenToEvent()
    {
        CarEvent.Instance.OnDrift -= OnDrift;
        CarEvent.Instance.OnStopDrift -= OnStopDrift;
        CarEvent.Instance.OnSpawnNewCar -= OnSpawnNewCar;
        CarEvent.Instance.OnDisabled -= SetActiveGO;
    }

    public void FixedUpdate()
    {
        stateMachine.ExecuteStateUpdate();
    }

    public void SetCarSpawn()
    {
        SetActiveGO(true);
        carMotion.tf.position = new Vector3(0f, 0f, 0f);
        stateMachine.ChangeState(carStateInstance.moveForward);
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

    //-------------------------------------EVENTS-------------------------------------------

    public void OnDrift()
    {
        if (IsActive() && carMotion.CompareState(CarState.MoveForward))
        {
            stateMachine.ChangeState(carStateInstance.driftState);
        }
    }

    public void OnStopDrift()
    {
        if (IsActive() && carMotion.CompareState(CarState.Drifting))
        {
            stateMachine.ChangeState(carStateInstance.stopDriftState);
        }
    }

    public void Test()
    {
        Debug.Log("Testtttt!!");
    }
}
