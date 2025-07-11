using Godot;
using System;

public partial class EnemySpawner : Marker2D
{
	[Export] public string[] EnemyList = [];
	[Export] public MovementRes[] MoveRes = [];
	[Export] public BulletPatternRes[] PatternRes = [];
	[Export] public float InitialWait = 1f;
	[Export] public float SpawnInterval = 0.5f;
	private float _spawnInterval = 0f;
	private bool _duringInitialWait = true;
	private int _spawnCount = 0;
	public override void _Ready()
	{
	}

	public override void _PhysicsProcess(double delta)
	{
		InitialTimer(delta);
		SpawnTimer(delta);
	}
	public void Spawn(string enemyName)
	{
		_spawnCount++;
		Enemy enemy = ResourceLoader.Load<PackedScene>($"res://Enemy/{enemyName}.tscn").Instantiate<Enemy>();
		enemy.Position = Position;
		GetParent().AddChild(enemy);
	}
	public void InitialTimer(double delta)
	{
		if (!_duringInitialWait) return;
		InitialWait -= (float)delta;
		if (InitialWait < 0) _duringInitialWait = false;
	}
	public void SpawnTimer(double delta)
	{
		if (_duringInitialWait || _spawnCount >= EnemyList.Length) return;
		_spawnInterval -= (float)delta;
		if (_spawnInterval < 0)
		{
			_spawnInterval = SpawnInterval;
			Spawn(EnemyList[_spawnCount]);
		}
	}
}
