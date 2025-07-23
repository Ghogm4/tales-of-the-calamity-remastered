using Godot;
using System;
[GlobalClass]
public partial class SetValue : Statement
{
    [Export] public string VariableName = "";
    [Export] public Arithmetic ValueToBeSet = null;
    public override bool Run()
    {
        ControlStatement currentScope = Parent;
        while (currentScope != null)
        {
            if (currentScope.VariableList.ContainsKey(VariableName))
            {
                currentScope.VariableList[VariableName] = ValueToBeSet.GetValue(currentScope);
                return true;
            }
            else
            {
                currentScope = currentScope.Parent;
            }
        }
        return true;
    }
}
