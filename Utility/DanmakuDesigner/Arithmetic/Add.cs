using Godot;
using System;

public partial class Add : Arithmetic
{
    [Export] public Arithmetic LeftOperand = new();
    [Export] public Arithmetic RightOperand = new();
    public override float GetValue()
    {
        return LeftOperand.GetValue() + RightOperand.GetValue();
    }
}
