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
    public LaunchMode Mode = LaunchMode.Fixed;
    public float FixedAngle = 0f;
    public int BulletCount = 8;
    public MovementRes[] MoveRes = [];
    public override void Launch()
    {
        float currentRadian = GetRadian();
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
    private float GetRadian()
    {
        switch (Mode)
        {
            case LaunchMode.Random:
                return (float)GD.RandRange(0, Math.Tau);
            case LaunchMode.Fixed:
                return FixedAngle * Mathf.Tau / 180;
            case LaunchMode.Player:
                return (GameManager.GamePlayer.Position - Position).Angle();
            default:
                return 0f;
        }
    }
}
