using System;
using UnityEngine;

public class CarEvent : Singleton<CarEvent>
{
    // public event Action<string, int, float> OnCheckFireBullet;
    // public void CheckFireBullet(string tag, int randomUnit, float damage) { if (OnCheckFireBullet != null) OnCheckFireBullet.Invoke(tag, randomUnit, damage); }

    public event Action OnMoveForward;
    public void MoveForward() { if (OnMoveForward != null) OnMoveForward(); }

    public event Action OnDrift;
    public void Drift() { if (OnDrift != null) OnDrift(); }

    public event Action OnStopDrift;
    public void StopDrift() { if (OnStopDrift != null) OnStopDrift(); }

    public event Action OnSpawnNewCar;
    public void SpawnNewCar() { if (OnSpawnNewCar != null) OnSpawnNewCar(); }

    public event Action OnTest;
    public void Test() { if (OnTest != null) OnTest(); }
}
