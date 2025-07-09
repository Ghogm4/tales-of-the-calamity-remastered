using Godot;
using System;
[GlobalClass]
public partial class MovementRes : Resource
{
    [Export] public float TransitionTime = 1f;
    public virtual Movement Create()
    {
        return default;
    }
}
