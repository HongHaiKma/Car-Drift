using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelSkids : MonoBehaviour
{
    public float intensity = 1.5f;

    Skidmarks skidController;
    public CarController playerCar;
    int lastSkidId = -1;

    public Transform tf;

    private void Awake()
    {
        tf = GetComponent<Transform>();
        skidController = FindObjectOfType<Skidmarks>();
        // playerCar = GetComponentInParent<PlayerCar>();
    }

    void LateUpdate()
    {
        float intensity = playerCar.sideSlipAmount;

        if (intensity < 0)
        {
            intensity = -intensity;
        }

        if (intensity > 0.1f)
        {
            lastSkidId = skidController.AddSkidMark(tf.position, tf.up, intensity * this.intensity, lastSkidId);
        }
        else
        {
            lastSkidId = -1;
        }
    }
}
