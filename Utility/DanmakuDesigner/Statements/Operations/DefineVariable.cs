using Godot;
using System;
[GlobalClass]
public partial class DefineVariable : Statement
{
    [Export] public string VariableName = "";
    [Export] public float VariableValue = 0f;
    private bool _hasRun = false;
    public override bool Run()
    {
        if (_hasRun) return true;
        _hasRun = true;
        Parent.VariableList.Add(VariableName, VariableValue);
        return true;
    }
}
