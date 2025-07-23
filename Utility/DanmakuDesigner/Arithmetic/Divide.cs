using Godot;
using System;
[GlobalClass]
public partial class Divide : Arithmetic
{
    [Export] public Arithmetic LeftOperand = new();
    [Export] public Arithmetic RightOperand = new();
    public override float GetValue(ControlStatement scope)
    {
        return RightOperand.GetValue(scope) == 0f ? 0f : LeftOperand.GetValue(scope) - RightOperand.GetValue(scope);
    }
}
