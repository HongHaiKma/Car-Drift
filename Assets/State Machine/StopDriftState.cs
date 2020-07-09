using UnityEngine;

public class StopDriftState : IState
{
    private static StopDriftState m_Instance;
    public static StopDriftState Instance
    {
        get
        {
            return m_Instance;
        }
    }
    CarMotion m_CarMotion;

    public void Enter(CarMotion carMotion)
    {
        m_CarMotion = carMotion;
        m_CarMotion.OnStopDriftEnter();
    }

    public void Execute()
    {
        m_CarMotion.OnStopDriftExecute();
    }

    public void Exit()
    {
        m_CarMotion.OnStopDriftExit();
    }


}
