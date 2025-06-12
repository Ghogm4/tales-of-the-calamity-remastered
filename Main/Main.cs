using Godot;
using System;

public partial class Main : Node
{
	public override void _Ready()
	{
		Bullet b = ResourceLoader.Load<PackedScene>("res://Bullet/Bullet/Bullet.tscn").Instantiate<Bullet>();
		b.LifeTime = 10f;

        Circular circular = new(null, 999f, b, 150, 0, new Vector2(400, 500), false);
        Accelerative accelerative = new(null, 2f, b, new Vector2(0, 500));
        accelerative.NextMovement = circular;
		accelerative.ReceiveVelocity(new Vector2(500, 0));
        b.AddChild(circular);
		b.AddChild(accelerative);
		b.TransitToNextMovement(accelerative);
        AddChild(b);
		b.ReturnWhenExit = true;
	}

	public override void _Process(double delta)
	{

    }
}
