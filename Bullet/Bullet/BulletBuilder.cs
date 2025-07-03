using Godot;
using System;
using System.ComponentModel.DataAnnotations;

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
	public BulletBuilder SetBulletSpecific(float lifeTime, bool returnWhenExit)
	{
		_result.LifeTime = lifeTime;
		_result.ReturnWhenExit = returnWhenExit;
		return this;
	}
	public BulletBuilder SetMovementPhases(Vector2 initialVelocity, params Movement[] movements)
	{
        movements[0].ReceiveVelocity(initialVelocity);
        for (int i = 0; i < movements.Length - 1; ++i)
        {
            movements[i].NextMovement = movements[i + 1];
        }
        foreach (Movement movement in movements)
        {
            _result.AddChild(movement);
            movement.Context = _result;
        }
		movements[0].IsFirstInChain = true;
		return this;
	}
}
