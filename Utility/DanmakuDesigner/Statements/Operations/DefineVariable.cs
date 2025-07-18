using Godot;
using System;

public partial class DefineVariable : Statement
{
    [Export] public string VariableName = "";
    [Export] public float VariableValue = 0f;
}
