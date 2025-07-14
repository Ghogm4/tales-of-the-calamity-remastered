using Godot;
using System;

public partial class BulletSource : Node2D
{
	public float OffsetAngle = 0f;
	public float SpreadAngle = 0f;
	private float _finalRadian = 0f;
	public void Launch(float angle)
	{
		float spreadAngle = Mathf.Abs(SpreadAngle);
		_finalRadian = (angle + OffsetAngle + (float)GD.RandRange(0, spreadAngle)) * Mathf.Pi / 180;
		CreateBullet();
	}
	protected virtual void CreateBullet()
	{

	}
}
