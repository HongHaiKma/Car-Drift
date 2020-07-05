using System;
using UnityEngine;

public class CarEvent : Singleton<CarEvent>
{
    // public event Action<string, int, float> OnCheckFireBullet;
    // public void CheckFireBullet(string tag, int randomUnit, float damage) { if (OnCheckFireBullet != null) OnCheckFireBullet.Invoke(tag, randomUnit, damage); }

    public event Action OnDrift;
    public void Drift() { if (OnDrift != null) OnDrift(); }
}
