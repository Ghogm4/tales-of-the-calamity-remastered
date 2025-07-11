using Godot;
using System;
[GlobalClass]
public partial class BulletPatternRes : Resource
{
    [Export] public float InitialWait = 1f;
    [Export] public float FireWait = 1f;
    [Export] public float BurstWait = 0.2f;
    [Export] public int BurstCount = 3;
    [Export] public float LifeTime = 10;
    [Export] public bool ReturnWhenExit = false;
    [Export] public float BulletInitialSpeed = 150f;
    [Export] public Vector2 InitialVelocity = Vector2.Zero;
    [Export] public MovementRes[] MoveRes = [];
    public virtual BulletPattern Create()
    {
        return default;
    }
}
