using UnityEngine;

public class MoveForwardState : IState
{
    private static MoveForwardState m_Instance;
    public static MoveForwardState Instance
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
        m_CarMotion.OnMoveForwardEnter();
    }

    public void Execute()
    {
        m_CarMotion.OnMoveForwardExecute();
    }

    public void Exit()
    {
        m_CarMotion.OnMoveForwardExit();
    }


}
