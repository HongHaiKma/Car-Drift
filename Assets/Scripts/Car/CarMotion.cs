using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMotion : MonoBehaviour
{
    [Header("Components")]
    public Transform tf;
    public Rigidbody rb;
    public CarController carController;
    public CarCollision carCollision;

    [Header("Drift parameter")]
    public CarState carState;
    public bool driftLeft;

    public float turnAngle;
    public float turnSpeed;
    public float turnDriftSpeed;
    public float forwardDriftSpeed;
    public float speed;
    public Speed spdType;

    [Header("Slip")]
    Vector3 lastPosition;
    public float sideSlipAmount;

    // [Header("State")]
    // public StateMachine stateMachine;
    // public CarStateInstance carStateInstance;

    void Awake()
    {
        CacheComponents();
    }

    private void OnDisable()
    {
        // CancelInvoke("SetDeactiveCar");
        // CancelInvoke();
        Debug.Log("OnDisabled called!!!");
    }

    public void CacheComponents()
    {
        tf = GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();
        carController = GetComponent<CarController>();
        carCollision = GetComponent<CarCollision>();
    }

    public void MoveForward()
    {
        rb.velocity = Vector3.forward * speed;
    }

    public void SetSideSlip()
    {
        Vector3 direction = tf.position - lastPosition;
        Vector3 movement = tf.InverseTransformDirection(direction);
        lastPosition = tf.position;

        sideSlipAmount = movement.x;
    }

    public void SetupNewCarStatus()
    {
        // collider.enabled = false;

        turnAngle = 0f;
        turnSpeed = 350f;

        speed = 70f;

        turnDriftSpeed = 150f;
        forwardDriftSpeed = 70f;

        tf.position = new Vector3(0f, 0f, 0f);
        tf.rotation = Quaternion.Euler(0f, 0f, 0f);
    }

    public void StopMotion()
    {
        speed = 0;
        turnDriftSpeed = 0;
        forwardDriftSpeed = 0f;
        turnSpeed = 0;
        rb.velocity = new Vector3(0f, 0f, 0f);
    }

    public bool IsActive()
    {
        return gameObject.activeInHierarchy;
    }

    //-------------------------------------STATES-------------------------------------------
    public bool CompareState(CarState state)
    {
        return carState == state ? true : false;
    }

    public void OnDriftEnter()
    {
        carState = CarState.Drifting;

        driftLeft = PoolManager.Instance.PickNearestTarget(tf.position);
        //Choose drift direction
    }

    public void OnDriftExecute()
    {
        if (driftLeft)
        {
            DriftLeft();
        }
        else
        {
            DriftRight();
        }
    }

    public void OnDriftExit()
    {

    }

    public void DriftLeft()
    {
        rb.AddRelativeForce(Vector3.forward * forwardDriftSpeed);
        rb.AddRelativeForce(Vector3.left * turnDriftSpeed);

        turnAngle -= turnSpeed * Time.fixedDeltaTime;
        rb.rotation = Quaternion.Euler(0, turnAngle, 0);

        SetSideSlip();
    }

    public void DriftRight()
    {
        rb.AddRelativeForce(Vector3.forward * forwardDriftSpeed);
        rb.AddRelativeForce(Vector3.right * turnDriftSpeed);

        turnAngle += turnSpeed * Time.fixedDeltaTime;
        rb.rotation = Quaternion.Euler(0, turnAngle, 0);

        SetSideSlip();
    }

    public void OnMoveForwardEnter()
    {
        carState = CarState.MoveForward;
    }

    public void OnMoveForwardExecute()
    {
        MoveForward();
    }

    public void OnMoveForwardExit()
    {

    }

    public void OnStopDriftEnter()
    {
        Debug.Log("On stop drift enter!!!");
        carState = CarState.StopDrifting;
        StopMotion();

        if (IsActive())
        {
            carCollision.CheckParking();
        }

        // Invoke("SetDeactiveCar", 1.5f);
    }

    public void SetDeactiveCar()
    {
        SetActiveGO(false);
    }

    public void SetActiveGO(bool status)
    {
        gameObject.SetActive(status);
    }

    public void OnStopDriftExecute()
    {

    }

    public void OnStopDriftExit()
    {

    }

    public void OnIdleEnter()
    {
        carState = CarState.Idle;
        StopMotion();
    }

    public void OnIdleExecute()
    {

    }

    public void OnIdleExit()
    {

    }
}
