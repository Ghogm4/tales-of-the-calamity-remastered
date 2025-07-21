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
        ControlStatement parent = Parent;
        while (parent != null)
        {
            if (parent.VariableList.ContainsKey(variableName))
            {
                return parent.VariableList[variableName];
            }
            else
            {
                parent = parent.Parent;
            }
        }
        return 0f;
    }
}
