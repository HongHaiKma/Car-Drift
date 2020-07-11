using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnButton : MonoBehaviour
{
    // public Button btn;

    public void BeginDrift()
    {
        CarEvent.Instance.Drift();
        Debug.Log("On click button begin drift!!!");
    }

    public void StopDrift()
    {
        Debug.Log("Click stop drift!!!");
        UIManager.Instance.btn_Drift.interactable = false;
        CarEvent.Instance.StopDrift();

        if (GameManager.Instance.gameStart)
        {
            // CarEvent.Instance.SpawnNewCar();
            PoolManager.Instance.ActivateNewCar();
        }
    }
}
