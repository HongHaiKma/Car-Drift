using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMotion : MonoBehaviour
{
    [Header("Components")]
    public Transform tf;
    public Rigidbody rb;
    public CarController carController;

    [Header("Drift parameter")]
    public CarState carState;
    public bool driftLeft;
    public bool drifting = false;

    public float turnAngle;
    public float turnSpeed;
    public float turnDriftSpeed;
    public float forwardDriftSpeed;
    public float speed;

    [Header("Slip")]
    Vector3 lastPosition;
    public float sideSlipAmount;

    void Awake()
    {
        CacheComponents();
    }

    public void CacheComponents()
    {
        tf = GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();
        carController = GetComponent<CarController>();
    }

    void OnEnable()
    {
        SetupNewCarStatus();
        StartListenToEvent();

        CarEvent.Instance.Drift();
    }

    void OnDisable()
    {
        StopListenToEvent();
    }

    public void StartListenToEvent()
    {
        CarEvent.Instance.OnDrift += OnDrift;
    }

    public void StopListenToEvent()
    {
        CarEvent.Instance.OnDrift -= OnDrift;
    }

    public void Drift()
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

    public void DriftLeft()
    {
        drifting = true;

        rb.AddRelativeForce(Vector3.forward * forwardDriftSpeed);
        rb.AddRelativeForce(Vector3.left * turnDriftSpeed);

        turnAngle -= turnSpeed * Time.fixedDeltaTime;
        rb.rotation = Quaternion.Euler(0, turnAngle, 0);
    }

    public void DriftRight()
    {
        drifting = true;

        rb.AddRelativeForce(Vector3.forward * forwardDriftSpeed);
        rb.AddRelativeForce(Vector3.right * turnDriftSpeed);

        turnAngle += turnSpeed * Time.fixedDeltaTime;
        rb.rotation = Quaternion.Euler(0, turnAngle, 0);
    }

    public void KeepMovingForward()
    {
        rb.velocity = Vector3.forward * speed;
    }

    public void OnDrift()
    {
        if (carController.IsActive())
        {
            Debug.Log("OnDrift!!!");
        }
    }

    public void SetSideSlip()
    {
        Vector3 direction = tf.position - lastPosition;
        Vector3 movement = tf.InverseTransformDirection(direction);
        lastPosition = tf.position;

        sideSlipAmount = movement.x;
    }

    public float CalDistance(Vector2 origin, Vector2 des)
    {
        return Vector2.Distance(origin, des);
    }

    public float CalDistance(Vector3 origin, Vector3 des)
    {
        return Vector3.Distance(origin, des);
    }

    public void SetupNewCarStatus()
    {
        carState = CarState.MoveForward;
        drifting = false;

        turnAngle = 0f;
        turnSpeed = 300f;

        speed = 70f;
        turnDriftSpeed = 90f;
        forwardDriftSpeed = 120f;

        tf.position = new Vector3(0f, 0f, 0f);
        tf.rotation = Quaternion.Euler(0f, 0f, 0f);
    }

    public void StopCarMotion()
    {
        speed = 0;
        turnDriftSpeed = 0;
        forwardDriftSpeed = 0f;
        turnSpeed = 0;
        rb.velocity = new Vector3(0f, 0f, 0f);
    }
}
