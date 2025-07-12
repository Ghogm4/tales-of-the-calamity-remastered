using Godot;
using System;
using System.Collections.Generic;

public partial class EnemySpawner : Marker2D
{
	[Export] public string[] EnemyList = [];
    [Export] public Vector2 InitialVelocity = Vector2.Zero;
    [Export] public MovementRes[] MoveRes = [];
	[Export] public BulletPatternRes[] PatternRes = [];
	[Export] public float InitialWait = 1f;
	[Export] public float SpawnInterval = 0.5f;
	private float _spawnInterval = 0f;
	private bool _duringInitialWait = true;
	private int _spawnCount = 0;
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
        SetMovementPhases(enemy);
		BindbulletPatterns(enemy);
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
	public void SetMovementPhases(Enemy enemy)
	{
        List<Movement> movements = new();
        foreach (MovementRes res in MoveRes)
        {
            movements.Add(res.Create());
        }
        movements[0].ReceiveVelocity(InitialVelocity);
        for (int i = 0; i < movements.Count - 1; ++i)
        {
            movements[i].NextMovement = movements[i + 1];
        }
        foreach (Movement movement in movements)
        {
            enemy.AddChild(movement);
            movement.Context = enemy;
        }
        movements[0].IsFirstInChain = true;
    }
	public void BindbulletPatterns(Enemy enemy)
	{
		foreach (BulletPatternRes res in PatternRes)
		{
			BulletPattern pattern = res.Create();
			pattern.Position = Vector2.Zero;
			enemy.AddChild(pattern);
		}
	}
}
