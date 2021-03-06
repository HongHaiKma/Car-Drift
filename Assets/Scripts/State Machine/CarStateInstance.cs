﻿public class CarStateInstance
{
    public IState moveForward;
    public IState driftState;
    public IState stopDriftState;
    public IState idleState;

    public CarStateInstance()
    {
        moveForward = new MoveForwardState();
        driftState = new DriftState();
        stopDriftState = new StopDriftState();
        idleState = new IdleState();
    }
}
