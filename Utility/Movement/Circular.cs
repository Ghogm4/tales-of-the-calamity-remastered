using Godot;
using System;

public partial class Circular : Movement
{
    public float? CurrentRadian = null;
    private float _radius = 50f;
    private float _radiusAcce = 200f;
    private Vector2 _pivot = Vector2.Zero;
    private float _angularSpeed = 1.57f;
    private int _direction = 0;
    public Circular(float transitionTime, float radius, float radiusAcce, Vector2 pivot, bool clockwise)
        : base(transitionTime)
    {
        _radius = radius;
        _radiusAcce = radiusAcce;
        _pivot = pivot;
        _direction = clockwise ? 1 : -1;
    }
    public override void _Ready()
    {
    }
    public override void UpdateContext(double delta)
    {
        if (CurrentRadian == null) CurrentRadian = (Context.Position - _pivot).Angle();
        Context.Position = new Vector2(
            _pivot.X + Mathf.Cos((float)CurrentRadian) * _radius,
            _pivot.Y + Mathf.Sin((float)CurrentRadian) * _radius
        );
        _radius += _radiusAcce * (float)delta;
        CurrentRadian += _angularSpeed * _direction * (float)delta;
    }
    public override void ReceiveVelocity(Vector2 velocity)
    {
        _angularSpeed = velocity.Length() / _radius;
    }
}
