using Godot;
using System;
using System.Threading;
using System.Threading.Tasks;
public partial class Bullet : Node2D
{
	
	public override void _Ready()
	{
	}

	public override void _Process(double delta)
	{
	}
	public virtual void ReturnToPool()
	{

	}
	public void OnScreenExited()
	{
		ReturnToPool();
	}
	public void OnLifeTimeExceeded()
	{
		ReturnToPool();
	}
	public void TransitToNextMovement(Movement movement)
	{

	}
}
