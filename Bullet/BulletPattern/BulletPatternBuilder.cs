using Godot;
using System;
using System.Collections.Generic;

public partial class BulletPatternBuilder : Node
{
    protected BulletPattern _result = new();
    public BulletPattern GetResult()
    {
        return _result;
    }
    public BulletPatternBuilder SetBulletSpecific(float lifeTime, bool returnWhenExit, float bulletInitialSpeed)
    {
        _result.LifeTime = lifeTime;
        _result.ReturnWhenExit = returnWhenExit;
        _result.InitialSpeed = bulletInitialSpeed;
        return this;
    }
    public BulletPatternBuilder SetWait(float initialWait, float fireWait, float burstWait)
    {
        _result.InitialWait = initialWait;
        _result.FireWait = fireWait;
        _result.BurstWait = burstWait;
        return this;
    }
    public BulletPatternBuilder SetBurstCount(int burstCount)
    {
        _result.BurstCount = burstCount;
        return this;
    }
    public BulletPatternBuilder SetMovementPhases(Vector2 initialVelocity, params MovementRes[] movementRes)
    {
        List<Movement> movements = new();
        foreach (MovementRes res in movementRes)
        {
            movements.Add(res.Create());
        }
        movements[0].ReceiveVelocity(initialVelocity);
        for (int i = 0; i < movements.Count - 1; ++i)
        {
            movements[i].NextMovement = movements[i + 1];
        }
        foreach (Movement movement in movements)
        {
            _result.AddChild(movement);
            movement.Context = _result;
        }
        movements[0].IsFirstInChain = true;
        return this;
    }
}
