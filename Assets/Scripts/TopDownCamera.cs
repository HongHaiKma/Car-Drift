using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownCamera : Singleton<TopDownCamera>
{
    public Transform curCarTf;
    public float aheadSpeed;
    public float followDamp;
    public float cameraHeight;
    public Transform tf;

    void Awake()
    {
        tf = GetComponent<Transform>();
        // obserRb = obser.GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (curCarTf == null)
        {
            return;
        }

        // Vector3 curCarPos = curCarTf.position + Vector3.up * cameraHeight + curCarRb.velocity * aheadSpeed;

        // tf.position = Vector3.Lerp(tf.position, targetPosition, followDamp * Time.deltaTime);
        tf.position = curCarTf.position + Vector3.up * cameraHeight;
    }
}
