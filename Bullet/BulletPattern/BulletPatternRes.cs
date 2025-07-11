using Godot;
using System;

public partial class BulletPatternRes : Resource
{
    [Export] public float InitialWait = 1f;
    [Export] public float FireWait = 1f;
    [Export] public float BurstWait = 0.2f;
    [Export] public int BurstCount = 3;
    [Export] public float LifeTime = 10;
    [Export] public bool ReturnWhenExit = false;
    public virtual BulletPattern Create()
    {
        return default;
    }
}
