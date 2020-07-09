using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarStateInstance
{
    public IState moveForward;
    public IState driftState;
    public IState stopDriftState;

    public CarStateInstance()
    {
        moveForward = new MoveForwardState();
        driftState = new DriftState();
        stopDriftState = new StopDriftState();
    }
}
