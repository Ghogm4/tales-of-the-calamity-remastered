using Godot;
using System;
[GlobalClass]
public partial class Add : Arithmetic
{
    [Export] public Arithmetic LeftOperand = new();
    [Export] public Arithmetic RightOperand = new();
    public override float GetValue(ControlStatement scope)
    {
        return LeftOperand.GetValue(scope) + RightOperand.GetValue(scope);
    }
}
