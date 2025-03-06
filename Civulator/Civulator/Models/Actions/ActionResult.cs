using Civulator.Models.Behavior;
using Civulator.Models.Pops;

namespace Civulator.Models.Actions;

public class ActionResult
{
    public string Name { get; private set; }
    public string Description { get; private set; }
    public int Duration { get; private set; }
    
    private Dictionary<ChangeLabel, float> _valueChanges { get; } = [];

    public ActionResult(string name, string description, int duration)
    {
        Name = name;
        Description = description;
        Duration = duration;
    }

    public ActionResult(string name, string description, int duration, Dictionary<ChangeLabel, float> valueChanges)
    {
        Name = name;
        Description = description;
        Duration = duration;
        _valueChanges = valueChanges;
    }

    public ActionResult(string name, string description)
    {
        Name = name;
        Description = description;
        Duration = 1;
    }

    public void AddValueChange(ChangeLabel changeLabel, float value)
    {
        _valueChanges.Add(changeLabel, value);
    }

    public IPop ApplyChanges(IPop pop)
    {
        foreach (var change in _valueChanges)
        {
            pop.ChangeValue(change.Key, change.Value);
        }
        return pop;
    }
}
