using Civulator.Models.Behavior;
using Civulator.Models.Conditions;

namespace Civulator.Models.Actions;

public interface IAction
{
    public string Name { get; protected set; }
    public int Duration { get; protected set; }
    public List<ICondition> PossibleConditions { get; protected set; }
    public List<ICondition> RequiredConditions { get; protected set; }
    public List<ICondition> BlockedConditions { get; protected set; }

    public Task Execute(BehaviorContext context);
}
