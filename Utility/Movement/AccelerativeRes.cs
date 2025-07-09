using Godot;
using System;
[GlobalClass]
public partial class AccelerativeRes : MovementRes
{
    [Export] public Vector2 Acceleration = Vector2.Zero;
    public override Accelerative Create()
    {
        return new Accelerative(TransitionTime, Acceleration);
    }
}
