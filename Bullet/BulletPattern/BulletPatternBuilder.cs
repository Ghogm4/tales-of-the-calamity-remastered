using Godot;
using System;
using System.Collections.Generic;

public partial class BulletPatternBuilder<TBuilder, TResult> : Node
    where TBuilder : BulletPatternBuilder<TBuilder, TResult>
    where TResult : BulletPattern, new()
{
    protected TResult _result = new();
    public virtual TResult GetResult()
    {
        return _result;
    }
    public TBuilder SetBulletSpecific(float lifeTime, bool returnWhenExit, float bulletInitialSpeed, MovementRes[] moveRes)
    {
        _result.LifeTime = lifeTime;
        _result.ReturnWhenExit = returnWhenExit;
        _result.InitialSpeed = bulletInitialSpeed;
        _result.MoveRes = moveRes;
        return this as TBuilder;
    }
    public TBuilder SetWait(float initialWait, float fireWait, float burstWait)
    {
        _result.InitialWait = initialWait;
        _result.FireWait = fireWait;
        _result.BurstWait = burstWait;
        return this as TBuilder;
    }
    public TBuilder SetBurstCount(int burstCount)
    {
        _result.BurstCount = burstCount;
        return this as TBuilder;
    }
    public TBuilder SetMovementPhases(Vector2 initialVelocity, params MovementRes[] movementRes)
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
        return this as TBuilder;
    }
}
