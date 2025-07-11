using Godot;
using Godot.Collections;
using System;
using static CircShot;
[GlobalClass]
public partial class CircShotRes : BulletPatternRes
{
    [Export] public LaunchMode Mode = LaunchMode.Random;
    [Export] public float FixedAngle = 0f;
    [Export] public int BulletCount = 8;
    public override CircShot Create()
    {
        CircShotBuilder builder = new();
        builder
            .SetBurstCount(BurstCount)
            .SetBulletSpecific(LifeTime, ReturnWhenExit, BulletInitialSpeed)
            .SetMovementPhases(InitialVelocity, MoveRes)
            .SetWait(InitialWait, FireWait, BurstWait);
        builder.SetCircShotSpecific(Mode, BulletCount, FixedAngle);
        return builder.GetResult() as CircShot;
    }
}
