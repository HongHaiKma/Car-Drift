using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public bool gameStart = false;

    private void Awake()
    {
        gameStart = false;
    }

    public void StartGame()
    {
        gameStart = true;
        UIManager.Instance.CloseStartGamePopup();
        PoolManager.Instance.ActivateNewCar();
    }

    public void StopGame()
    {
        gameStart = false;
        UIManager.Instance.OpenStartGamePopup();
        UIManager.Instance.startPopup.SetActive(true);
        Debug.Log("Stop game!!!");
    }

    public void StopGame1()
    {
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }
}
