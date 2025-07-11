using Godot;
using System;
using static CircShot;
public partial class CircShotBuilder : BulletPatternBuilder
{
    public CircShotBuilder SetCircShotSpecific(LaunchMode mode, int bulletCount, float fixedAngle = 0f)
    {
        CircShot _resultCirc = _result as CircShot;
        _resultCirc.Mode = mode;
        _resultCirc.BulletCount = bulletCount;
        _resultCirc.FixedAngle = fixedAngle;
        return this;
    }
}
