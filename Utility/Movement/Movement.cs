using Godot;
using System;

public partial class Movement : Node
{
    public Movement NextMovement = null;
    public float TransitionTime = 1f;
    public Node2D Context = null;
    public bool IsFirstInChain = false;
    private Vector2 _lastPosition = Vector2.Zero;
    private float _frameDuration = 0.0167f;
    public Movement(float transitionTime)
    {
        TransitionTime = transitionTime;
    }
    public override void _Ready()
    {
        _lastPosition = Context.Position;
        if (!IsFirstInChain) SetPhysicsProcess(false);
    }
    public Vector2 GetVelocity() => (Context.Position - _lastPosition) / _frameDuration;
    public virtual void UpdateContext(double delta)
    {
    }
    public void UpdateLast(double delta)
    {
        if (TransitionTime < 0)
        {
            if (NextMovement == null) return;
            NextMovement.ReceiveVelocity(GetVelocity());
            NextMovement.SetPhysicsProcess(true);
            SetPhysicsProcess(false);
        }
        float deltaF = (float)delta;
        _frameDuration = deltaF;
        _lastPosition = Context.Position;
        TransitionTime -= deltaF;
    }
    public void Update(double delta)
    {
        UpdateLast(delta);
        UpdateContext(delta);
    }
    public virtual void ReceiveVelocity(Vector2 velocity)
    {

    }
    public override void _PhysicsProcess(double delta)
    {
        Update(delta);
    }
}
