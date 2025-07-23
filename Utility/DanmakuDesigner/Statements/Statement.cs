using Godot;
using System;
[GlobalClass]
public partial class Statement : Resource
{
    public ControlStatement Parent = null;
    public virtual bool Run()
    {
        return true;
    }
    public virtual void Refresh()
    {
    }
    public float FindVariable(string variableName)
    {
        ControlStatement currentScope = Parent;
        while (currentScope != null)
        {
            if (currentScope.VariableList.ContainsKey(variableName))
            {
                return currentScope.VariableList[variableName];
            }
            else
            {
                currentScope = currentScope.Parent;
            }
        }
        return 0f;
    }
}
