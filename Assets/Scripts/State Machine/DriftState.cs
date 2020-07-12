using UnityEngine;

public class DriftState : IState
{
    private static DriftState m_Instance;
    public static DriftState Instance
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
        m_CarMotion.OnDriftEnter();
    }

    public void Execute()
    {
        m_CarMotion.OnDriftExecute();
    }

    public void Exit()
    {
        m_CarMotion.OnDriftExit();
    }
}
