using Civulator.Models.Behavior;
using Civulator.Models.Conditions;

namespace Civulator.Models.Actions;

public abstract class ActionBase(string name, int duration) : IAction
{
    public string Name { get; set; } = name;
    public int Duration { get; set; } = duration;

    protected abstract Func<BehaviorContext, KeyValuePair<BehaviorState, BehaviorContext>> DetermineConditions { get; set; }

    public virtual Task<BehaviorState> Execute(ref BehaviorContext context)
    {
        var result = DetermineConditions(context);
        var resultState = result.Key;
        context = result.Value;
        
        switch (resultState)
        {
            case BehaviorState.Success:
                // TODO: Apply changes to the context
                break;
            case BehaviorState.Idle:
                // Changes blocked
                break;
            case BehaviorState.Failure:
                // Check condition failed
                break;
            default:
                throw new Exception($"Received invalid BehaviorState: {Name}");
        }

        return Task.FromResult(resultState);
    }

}
