using Godot;
using System;

public partial class Divide : Arithmetic
{
    [Export] public Arithmetic LeftOperand = new();
    [Export] public Arithmetic RightOperand = new();
    public override float GetValue()
    {
        return RightOperand.GetValue() == 0f ? 0f : LeftOperand.GetValue() - RightOperand.GetValue();
    }
}
