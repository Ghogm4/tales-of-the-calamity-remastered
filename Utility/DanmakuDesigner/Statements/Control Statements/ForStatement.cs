using Godot;
using System;

public partial class ForStatement : ControlStatement
{
    [Export] public string LoopVariableName = "";
    [Export] public float LoopVariableInitialValue = 0f;
    [Export] public float LoopVariableIncrement = 1f;
    [Export] public int LoopTimes = 10;
    private int _loopTimes = 0;
    private float? _loopVariableValue = null;
    public override bool Run()
    {
        if (_loopVariableValue == null) _loopVariableValue = LoopVariableInitialValue;
        if (_loopTimes >= LoopTimes) return true;

        if (_currentIndex == Statements.Length)
        {
            _loopTimes++;
            _currentIndex = 0;
            foreach (Statement statement in Statements)
            {
                statement.Refresh();
            }
            _loopVariableValue += LoopVariableIncrement;
            return false;
        }
        if (Statements[_currentIndex].Run())
        {
            _currentIndex++;
        }
        return false;
    }
}
