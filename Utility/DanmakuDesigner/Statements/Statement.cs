using Godot;
using System;

public partial class Statement : Resource
{
    public virtual bool Run()
    {
        return true;
    }
    public virtual void Refresh()
    {
    }
}
