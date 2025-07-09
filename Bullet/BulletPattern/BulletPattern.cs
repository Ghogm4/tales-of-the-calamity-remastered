using Godot;
using System;
[GlobalClass]
public partial class BulletPattern : Node
{
    [Export] public float InitialWait = 1f;
    [Export] public float FireWait = 1f;
    [Export] public float BurstWait = 0.2f;
    [Export] public int BurstCount = 3;
    [Export] public float LifeTime = 10;
    [Export] public bool ReturnWhenExit = false;
    private bool _duringInitialWait = true;
    private bool _duringFire = false;
    private float _fireWait = 1f;
    private float _burstWait = 0.2f;
    private int _burstCount = 3;
    public override void _Ready()
    {
        _fireWait = FireWait;
        _burstWait = BurstWait;
        _burstCount = BurstCount;
    }

    public override void _PhysicsProcess(double delta)
    {
        InitialTimer(delta);
        FireTimer(delta);
        BurstTimer(delta);
    }
    public virtual void Launch()
    {
    }
    public void InitialTimer(double delta)
    {
        if (!_duringInitialWait) return;
        InitialWait -= (float)delta;
        if (InitialWait < 0) _duringInitialWait = false;
    }
    public void FireTimer(double delta)
    {
        if (_duringInitialWait || _duringFire) return;
        _fireWait -= (float)delta;
        if (_fireWait < 0) _duringFire = true;
    }
    public void BurstTimer(double delta)
    {
        if (_duringInitialWait || !_duringFire) return;
        _burstWait -= (float)delta;
        if (_burstWait < 0)
        {
            Launch();
            _burstWait = BurstWait;
            _burstCount--;
        }
        if (_burstCount == 0)
        {
            _duringFire = false;
            _fireWait = FireWait;
            _burstCount = BurstCount;
        }
    }
}
