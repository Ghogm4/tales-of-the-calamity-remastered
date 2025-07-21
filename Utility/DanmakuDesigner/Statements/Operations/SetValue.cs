using Godot;
using System;

public partial class SetValue : Statement
{
    [Export] public string VariableName = "";
    [Export] public float VariableValue = 0f;
    public override bool Run()
    {
        ControlStatement parent = Parent;
        while (parent != null)
        {
            if (parent.VariableList.ContainsKey(VariableName))
            {
                parent.VariableList[VariableName] = VariableValue;
                return true;
            }
            else
            {
                parent = parent.Parent;
            }
        }
        return true;
    }
}
