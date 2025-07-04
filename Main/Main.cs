using Godot;
using System;

public partial class Main : Node
{
    public override void _Ready()
    {
        BulletBuilder builder = new();
        builder
            .SetMovementPhases(
            new Vector2(500, 0),
            new Accelerative(2f, new Vector2(0, 500)),
            new Circular(999f, 150, 50, new Vector2(400, 500), false)
            )
        .SetBulletSpecific(5f, true);
        AddChild(builder.GetResult());
        AddChild(new BulletPattern());
    }

    public override void _Process(double delta)
    {

    }
}
