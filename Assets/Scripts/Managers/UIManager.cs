using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    public Button btn_Drift;

    public GameObject startPopup;

    private void Awake()
    {

    }

    public void OpenStartGamePopup()
    {
        btn_Drift.interactable = false;
        startPopup.SetActive(true);
    }

    public void CloseStartGamePopup()
    {
        btn_Drift.interactable = true;
        startPopup.SetActive(false);
    }
}
