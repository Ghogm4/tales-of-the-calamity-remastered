using Godot;
using System;

public partial class Number : Arithmetic
{
    [Export] public string Value = "0";
    public override float GetValue()
    {
        float value = 0;
        if (float.TryParse(Value, out value))
        {
            return value;
        }
        return 0;
    }
}
