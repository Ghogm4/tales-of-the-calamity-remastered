using Godot;
using System;
using System.Threading;
using System.Threading.Tasks;
public partial class Bullet : Node2D
{
	public bool IsInPool = true;
	public float LifeTime = 10f;
	public bool ReturnWhenExit = false;
	private bool _isDisappearing = false;
	public override void _Ready()
	{
	}

	public override void _PhysicsProcess(double delta)
	{
		LifeTime -= (float)delta;
		if (LifeTime < 0 && !_isDisappearing) OnLifeTimeExceeded();
	}
	public virtual void ReturnToPool()
	{
		IsInPool = true;
		QueueFree();
	}
	public void OnScreenExited()
	{
		if (ReturnWhenExit) ReturnToPool();
	}
	public void OnLifeTimeExceeded()
	{
		_isDisappearing = true;
		Disappear();
	}
	public void Disappear()
	{
		Tween tween = GetTree().CreateTween();
		GetNode<InteractableArea>("InteractableArea").SetPhysicsProcess(false);
		tween.TweenProperty(this, "modulate:a", 0, 0.1f);
		tween.Parallel().TweenProperty(this, "scale", Vector2.Zero, 0.1f);
		tween.Finished += ReturnToPool;
	}
}
