using Godot;
using System;
[GlobalClass]
public partial class CircularRes : MovementRes
{
    [Export] public float Radius = 50f;
    [Export] public float RadiusAcce = 200f;
    [Export] public Vector2 Pivot = Vector2.Zero;
    [Export] public bool Clockwise = true;
    public override Circular Create()
    {
        return new Circular(TransitionTime, Radius, RadiusAcce, Pivot, Clockwise);
    }
}
