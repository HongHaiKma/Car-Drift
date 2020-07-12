using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine
{
    public IState curState;
    public IState prevState;
    private CarMotion m_CarMotion;

    public StateMachine(CarMotion carMotion)
    {
        m_CarMotion = carMotion;
    }

    public void Init(IState state)
    {
        this.curState = state;
        this.curState.Enter(m_CarMotion);
    }


    public void ChangeState(IState newsStage)
    {
        if (curState != newsStage)
        {
            if (curState != null)
            {
                this.curState.Exit();
            }
            this.prevState = this.curState;
            this.curState = newsStage;
            this.curState.Enter(m_CarMotion);
        }
    }

    public void ExecuteStateUpdate()
    {
        IState runningState = this.curState;

        if (runningState != null)
        {
            runningState.Execute();
        }
    }

    public void SwitchToPrevState()
    {
        this.curState.Exit();
        this.curState = this.prevState;
        this.curState.Enter(m_CarMotion);
    }

    public void FixedUpdate()
    {
        if (curState != null)
        {
            ExecuteStateUpdate();
        }
    }
}