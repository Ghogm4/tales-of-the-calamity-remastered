using Godot;
using Godot.Collections;
using System;
[Tool]
public partial class CircShotRes : BulletPatternRes
{
    public enum LaunchMode
    {
        Random,
        Fixed,
        Player
    }
    private LaunchMode _launchMode = LaunchMode.Random;
    private float _fixedAngle = 0f;
    [Export]
    public LaunchMode Mode
    {
        get => _launchMode;
        set
        {
            _launchMode = value;
            NotifyPropertyListChanged();
        }
    }
    public override Array<Dictionary> _GetPropertyList()
    {
        Array<Dictionary> properties = [];
        if (_launchMode == LaunchMode.Fixed)
        {
            properties.Add(new Dictionary()
            {
                {"name", "Fixed angle(0°~360°)"},
                {"type", (int)Variant.Type.Float},
            });
        }
        return properties;
    }
    public override Variant _Get(StringName property)
    {
        if (property.ToString() == "Fixed angle(0°~360°)") return _fixedAngle;
        return default;
    }
    public override bool _Set(StringName property, Variant value)
    {
        if (property.ToString() == "Fixed angle(0°~360°)")
        {
            _fixedAngle = value.As<float>();
            return true;
        }
        return false;
    }
    public override CircShot Create()
    {
        return new CircShot();
    }
}
