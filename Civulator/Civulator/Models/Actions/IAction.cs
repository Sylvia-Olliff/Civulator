using Civulator.Models.Behavior;
using Civulator.Models.Conditions;

namespace Civulator.Models.Actions;

public interface IAction
{
    public string Name { get; protected set; }
    public int Duration { get; protected set; }

    public Task<BehaviorState> Execute(ref BehaviorContext context);
}
