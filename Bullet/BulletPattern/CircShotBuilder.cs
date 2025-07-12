using Godot;
using System;
using static CircShot;
public partial class CircShotBuilder : BulletPatternBuilder<CircShotBuilder, CircShot>
{
    public CircShotBuilder SetCircShotSpecific(LaunchMode mode, int bulletCount, float fixedAngle = 0f)
    {
        _result.Mode = mode;
        _result.BulletCount = bulletCount;
        _result.FixedAngle = fixedAngle;
        return this;
    }
}
