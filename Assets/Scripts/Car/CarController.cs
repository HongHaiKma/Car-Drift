using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public Transform tf;
    public Rigidbody rb;

    public Quaternion targetRotation;
    // public float turnSpeed = 5f;
    public float turnAngle;
    public float turnSpeed;
    public float driftSpeed;
    public float speed;

    Vector3 lastPosition;
    public float sideSlipAmount;

    public bool turn = false;

    public bool drift = false;

    void Awake()
    {
        tf = GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();
    }

    void OnEnable()
    {
        SetupNewCarStatus();
    }

    public void Update()
    {
        // SetRotationPoint();
        // Rotation();

        if(Input.GetKeyDown("a"))
        {
            turn = true;
        }
        else if(Input.GetKeyDown("d"))
        {
            turn = true;
        }

        if(Input.GetKeyUp("a"))
        {
            speed = 0;
            driftSpeed = 0;
            turnSpeed = 0;
            rb.velocity = new Vector3(0f, 0f, 0f);

            if(!GameManager.Instance.lose)
            {
                StartCoroutine(CreateNewCar(false));
            }
        }
        else if(Input.GetKeyUp("d"))
        {
            speed = 0;
            driftSpeed = 0;
            turnSpeed = 0;
            rb.velocity = new Vector3(0f, 0f, 0f);
            
            if(!GameManager.Instance.lose)
            {
                StartCoroutine(CreateNewCar(false));
            }
        }

        SetSideSlip();
    }

    public void FixedUpdate()
    {
        Rotate();
        Drift();

        // tf.rotation = Quaternion.Lerp(tf.rotation, targetRotation, turnSpeed * Mathf.Clamp(speedLimit, -1, 1) * Time.fixedDeltaTime);
        // Rotation();
    }

    public void SetSideSlip()
    {
        Vector3 direction = tf.position - lastPosition;
        Vector3 movement = tf.InverseTransformDirection(direction);
        lastPosition = tf.position;

        sideSlipAmount = movement.x;
    }

    public void SetRotationPoint()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Plane plane = new Plane(Vector3.up, Vector3.zero);
        float distance;

        if(plane.Raycast(ray, out distance))
        {
            Vector3 target = ray.GetPoint(distance);
            Vector3 direction = target - tf.position;

            float rotationAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            targetRotation = Quaternion.Euler(0, rotationAngle, 0);
        }
    }

    public void Rotate()
    {
        if(Input.GetKey("a"))
        {
            drift = true;
            turnAngle -= turnSpeed * Time.fixedDeltaTime;
            rb.rotation = Quaternion.Euler(0, turnAngle, 0);
        }
        else if(Input.GetKey("d"))
        {
            drift = true;
            turnAngle += turnSpeed * Time.fixedDeltaTime;
            rb.rotation = Quaternion.Euler(0, turnAngle, 0);
        } 

        // if(Input.GetMouseButton(0))
        // {
        //     if(Input.mousePosition.x > Screen.width / 2)
        //     {
        //         turnAngle -= turnSpeed * Time.fixedDeltaTime;
        //         tf.rotation = Quaternion.Euler(0, turnAngle, 0);
        //     }
        //     else if(Input.mousePosition.x < Screen.width / 2)
        //     {
        //         turnAngle += turnSpeed * Time.fixedDeltaTime;
        //         tf.rotation = Quaternion.Euler(0, turnAngle, 0);
        //     }
        // }
    }

    public IEnumerator CreateNewCar(bool status)
    {
        EventManager.TriggerEvent(GameEvent.ActiveNewCar);
        yield return new WaitForSeconds(0.2f);
        SetActiveGO(false);
    }

    public void SetActiveGO(bool status)
    {
        gameObject.SetActive(status);
    }

    public void SetActiveGO(bool status, Vector3 startPos)
    {
        gameObject.SetActive(status);
        tf.position = startPos;
    }

    public void SetupNewCarStatus()
    {
        turnAngle = 0f;
        turnSpeed = 350f;
        speed = 60f;
        driftSpeed = 120f;
        turn = false;
        drift = false;
        tf.position = new Vector3(0f, 0.25f, 0f);
        tf.rotation = Quaternion.Euler(0f, 0f, 0f);
    }

    public void Drift()
    {
        if(drift)
        {
            rb.AddRelativeForce(Vector3.forward * driftSpeed);
            if(Input.GetKey("a"))
            {
                rb.AddRelativeForce(Vector3.left * driftSpeed);
            }
            else if(Input.GetKey("d"))
            {
                rb.AddRelativeForce(Vector3.right * driftSpeed);
            } 
            
        }
        else
        {
            rb.velocity = Vector3.forward * speed;
        }
    }
}
