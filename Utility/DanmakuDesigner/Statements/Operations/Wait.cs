using Godot;
using System;

public partial class Wait : Statement
{
    [Export] public int WaitFrames = 10;
    private int _elapsedFrames = 0;
    public override bool Run()
    {
        _elapsedFrames++;
        return _elapsedFrames >= WaitFrames;
    }
}
