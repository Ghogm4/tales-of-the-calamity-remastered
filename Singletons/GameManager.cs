using Godot;
using System;

public partial class GameManager : Node
{
	public static GameManager Instance;
	private GameManager() { }
	public override void _Ready()
	{
		Instance = this;
	}

	public override void _PhysicsProcess(double delta)
	{
	}
}
