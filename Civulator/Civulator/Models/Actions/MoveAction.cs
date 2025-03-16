using Civulator.Models.Behavior;
using Civulator.Models.Conditions;

namespace Civulator.Models.Actions;

public class MoveAction : ActionBase
{
    private Func<BehaviorContext, KeyValuePair<BehaviorState,BehaviorContext>>? _moveCondition = null;

    private List<ICondition> _blockedConditions = [];

    public MoveAction() : base("MoveAction", 1)
    {
        _moveCondition = (context) =>
        {
            // If the current context contains a condition on the blocked list, exit out of action.
            if (context.PopRef?.CurrentConditions.Where(cond => _blockedConditions.Contains(cond)).Count() > 0)
                return new (BehaviorState.Idle, context);

            // Determine the direction to take

            // Determine time to move based on duration and environment factors

            // Determine any conditions gained from the movement

            return new (BehaviorState.Success, context);
        };
    }

    protected override Func<BehaviorContext, KeyValuePair<BehaviorState, BehaviorContext>> DetermineConditions { 
        get {
            if (_moveCondition != null)
                return _moveCondition;
            else
                throw new AccessViolationException("Attempted to access movement condition without initialization");
        }
        set => _moveCondition = value;
    }
}
