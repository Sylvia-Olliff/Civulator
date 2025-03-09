using Civulator.Models.Behavior;
using Civulator.Models.Conditions;

namespace Civulator.Models.Actions;

public abstract class ActionBase(string name, int duration, List<ICondition> possibleConditions, List<ICondition> requiredConditions, List<ICondition> blockedConditions) : IAction
{
    public string Name { get; set; } = name;
    public int Duration { get; set; } = duration;
    public List<ICondition> PossibleConditions { get; set; } = possibleConditions;
    public List<ICondition> RequiredConditions { get; set; } = requiredConditions;
    public List<ICondition> BlockedConditions { get; set; } = blockedConditions;

    protected abstract Func<BehaviorContext,List<ICondition>, List<ICondition>> DetermineConditions { get; set; }

    public abstract Task Execute(BehaviorContext context);

}
