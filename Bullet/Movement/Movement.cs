using Godot;
using System;

public partial class Movement : Node
{
	public Movement NextMovement = null;
	public float TransitionTime = 1f;
	public Bullet Context = null;
	private Vector2 _lastPosition = Vector2.Zero;
	private float _frameDuration = 0.0167f;
	public Movement(Movement movement, float transitionTime, Bullet context)
	{
		NextMovement = movement;
		TransitionTime = transitionTime;
		Context = context;
	}
	public override void _Ready()
	{
		_lastPosition = Context.Position;
	}
	public Vector2 GetVelocity() => (Context.Position - _lastPosition) / _frameDuration;
	public virtual void UpdateContext(double delta)
	{
    }
	public void UpdateLast(double delta)
	{
		if (NextMovement != null && TransitionTime < 0)
		{
			Context.TransitToNextMovement(NextMovement);
			NextMovement.ReceiveVelocity(GetVelocity());
		}
		float deltaF = (float)delta;
        _frameDuration = deltaF;
        _lastPosition = Context.Position;
        TransitionTime -= deltaF;
    }
	public void Update(double delta)
	{
        UpdateLast(delta);
        UpdateContext(delta); 
    }
	public virtual void ReceiveVelocity(Vector2 velocity)
	{

	}
}
