using Godot;
using System;

public partial class Accelerative : Movement
{
	private Vector2 _velocity = Vector2.Zero;
	private Vector2 _acceleration = Vector2.Zero;
	public Accelerative(float transitionTime, Vector2 acceleration)
		: base(transitionTime)
	{
		_acceleration = acceleration;
	}
	public override void _Ready()
	{
		base._Ready();
	}
    public override void UpdateContext(double delta)
    {
		float deltaF = (float)delta;
		Context.Position += _velocity * deltaF;
		_velocity += _acceleration * deltaF;
    }
    public override void ReceiveVelocity(Vector2 velocity)
    {
        _velocity = velocity;
    }
}
