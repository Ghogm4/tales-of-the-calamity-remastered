using Godot;
using System;

public partial class BulletManager : Node
{
	public static BulletManager Instance;
	private BulletManager() { }
	public override void _Ready()
	{
		Instance = this;
	}

	public override void _Process(double delta)
	{
	}
}
