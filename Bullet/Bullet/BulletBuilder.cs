using Godot;
using System;

public partial class BulletBuilder : Node
{
	private Bullet _result = ResourceLoader.Load<PackedScene>("res://Bullet/Bullet/Bullet.tscn").Instantiate<Bullet>();
    public override void _Ready()
	{
	}
	public override void _Process(double delta)
	{
	}
	public Bullet GetResult()
	{
		return _result;
	}
	public BulletBuilder SetBulletSpecific(Vector2 initialVelocity, float lifeTime, bool returnWhenExit)
	{
		_result.LifeTime = lifeTime;
		_result.ReturnWhenExit = returnWhenExit;
		if (_result.CurrentMovement == null) GD.PrintErr("Set movement phases before setting bullet specific!");
		_result.CurrentMovement.ReceiveVelocity(initialVelocity);
		return this;
	}
	public BulletBuilder SetMovementPhases(params Movement[] movements)
	{
		for (int i = 0; i < movements.Length - 1; ++i)
		{
			movements[i].NextMovement = movements[i + 1];
		}
		foreach (Movement movement in movements)
		{
			_result.AddChild(movement);
			movement.Context = _result;
		}
		_result.TransitToNextMovement(movements[0]);
		return this;
	}
}
