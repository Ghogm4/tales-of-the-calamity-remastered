using Godot;
using System;
using System.Collections.Generic;

public partial class BulletPatternNew : Node2D
{
    public enum AimMode
    {
        Random,
        Fixed,
        Player
    }
    private AimMode _aimMode = AimMode.Random;
    public float InitialWait = 1f;
    public float FireWait = 0.5f;
    private float _fireWait = 0f;
    private bool _duringInitialWait = true;
    private float _fixedAngle = 0f;
    private List<BulletSource> _bulletSources = new();
    public override void _PhysicsProcess(double delta)
    {
        InitialTimer(delta);
        FireTimer(delta);
    }
    public virtual void Trigger()
    {
        foreach (BulletSource bulletSource in _bulletSources)
        {
            bulletSource.Launch(GetAngle());
        }
    }
    private void InitialTimer(double delta)
    {
        if (!_duringInitialWait) return;
        InitialWait -= (float)delta;
        if (InitialWait < 0) _duringInitialWait = false;
    }
    private void FireTimer(double delta)
    {
        if (_duringInitialWait) return;
        _fireWait -= (float)delta;
        if (_fireWait < 0)
        {
            _fireWait = FireWait;
            Trigger();
        }
    }
    private float GetAngle()
    {
        switch (_aimMode)
        {
            case AimMode.Random: return (float)GD.RandRange(0, 360f);
            case AimMode.Fixed: return _fixedAngle;
            case AimMode.Player: return (GameManager.GamePlayer.GlobalPosition - GlobalPosition).Angle() * 180 / Mathf.Pi;
            default: return 0f;
        }
    }
}
