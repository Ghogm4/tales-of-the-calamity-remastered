using Godot;
using System;

public partial class Minus : Arithmetic
{
    [Export] public Arithmetic LeftOperand = new();
    [Export] public Arithmetic RightOperand = new();
    public override float GetValue()
    {
        return LeftOperand.GetValue() - RightOperand.GetValue();
    }
}
