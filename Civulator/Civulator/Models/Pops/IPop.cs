using Civulator.Models.Actions;
using Civulator.Models.Behavior;
using Civulator.Models.Conditions;

namespace Civulator.Models.Pops;

public interface IPop
{
    public string Name { get; }
    public int AgeDays { get; }

    public PhysicalStats PhysicalStats { get; }

    public Behavior.Behavior SimpleBehaviorRoot { get; }
    public Behavior.Behavior ComplexBehaviorRoot { get; }
    public IAction CurrentAction { get; }
    public List<ICondition> CurrentConditions { get; }

    
    public void Act();

    public void MakeDecision();

}
