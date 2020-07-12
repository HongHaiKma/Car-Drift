using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnButton : MonoBehaviour
{
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
    }
}
