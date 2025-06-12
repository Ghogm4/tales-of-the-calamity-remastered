using Godot;
using System;

public partial class Accelerative : Movement
{
	private Vector2 _velocity = Vector2.Zero;
	private Vector2 _acceleration = Vector2.Zero;
	public Accelerative(Movement movement, float transitionTime, Bullet context, Vector2 acceleration)
		: base(movement, transitionTime, context)
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
