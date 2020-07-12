using UnityEngine;

public class IdleState : IState
{
    private static IdleState m_Instance;
    public static IdleState Instance
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
        m_CarMotion.OnIdleEnter();
    }

    public void Execute()
    {
        m_CarMotion.OnIdleExecute();
    }

    public void Exit()
    {
        m_CarMotion.OnIdleExit();
    }
}
