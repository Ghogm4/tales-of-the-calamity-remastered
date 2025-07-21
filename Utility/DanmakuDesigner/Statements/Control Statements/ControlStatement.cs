using Godot;
using Godot.Collections;
using System;

public partial class ControlStatement : Statement
{
    public Dictionary<string, float> VariableList = [];
    [Export] public Statement[] Statements = [];
    protected int _currentIndex = 0;
    public override bool Run()
    {
        return true;
    }
}
