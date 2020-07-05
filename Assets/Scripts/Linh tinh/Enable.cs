using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enable : MonoBehaviour
{
    public float time;

    private void OnEnable()
    {
        CancelInvoke();
        Invoke("Deactive", time);
    }

    private void Deactive()
    {
        if (gameObject.activeInHierarchy)
        {
            gameObject.SetActive(false);
        }
    }
}
