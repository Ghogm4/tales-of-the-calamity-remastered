using Godot;
using System;
[GlobalClass]
public partial class CircShot : BulletPattern
{
    public enum LaunchMode
    {
        Random,
        Fixed,
        Player
    }
    private LaunchMode _launchMode = LaunchMode.Fixed;
    [Export] public int BulletCount = 8;
    [Export] public MovementRes[] MoveRes = [];
    [Export] public float InitialSpeed = 150f;
    public override void Launch()
    {
        float currentRadian = (float)GD.RandRange(0, Math.Tau);
        float radianChange = (float)Math.Tau / BulletCount;
        for (int i = 0; i < BulletCount; ++i)
        {
            BulletBuilder builder = new("Bullet");
            builder.SetBulletSpecific(LifeTime, ReturnWhenExit)
                .SetMovementPhases((Vector2.Right * InitialSpeed).Rotated(currentRadian), MoveRes);
            GetParent().AddChild(builder.GetResult());
            currentRadian += radianChange;
        }
    }
}
