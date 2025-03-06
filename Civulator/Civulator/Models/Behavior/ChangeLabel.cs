namespace Civulator.Models.Behavior;

public struct ChangeLabel
{
    public string Name { get; }
    public string Description { get; }

    public float MinimumChangeValue { get; }
    public float MaximumChangeValue { get; }

    public ChangeLabel(string name, string description, float minimumChangeValue, float maximumChangeValue)
    {
        Name = name;
        Description = description;
        MinimumChangeValue = minimumChangeValue;
        MaximumChangeValue = maximumChangeValue;
    }

    public ChangeLabel(string name, string description)
    {
        Name = name;
        Description = description;
        MinimumChangeValue = 0.0f;
        MaximumChangeValue = 100.0f;
    }
}
