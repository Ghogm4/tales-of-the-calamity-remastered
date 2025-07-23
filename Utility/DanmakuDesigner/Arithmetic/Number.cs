using Godot;
using System;
[GlobalClass]
public partial class Number : Arithmetic
{
    [Export] public string Value = "0";
    public override float GetValue(ControlStatement scope)
    {
        float value = 0;
        if (float.TryParse(Value, out value))
        {
            return value;
        }
        ControlStatement currentScope = scope;
        while (currentScope != null)
        {
            if (currentScope.VariableList.ContainsKey(Value))
            {
                return currentScope.VariableList[Value];
            }
            else
            {
                currentScope = currentScope.Parent;
            }
        }
        return 0;
    }
}
