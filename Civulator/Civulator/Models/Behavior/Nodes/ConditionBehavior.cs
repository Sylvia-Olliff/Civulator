namespace Civulator.Models.Behavior.Nodes;

public class ConditionBehavior : Behavior
{
    private Func<BehaviorContext, bool> Condition { get; set; }

    public bool IsSequential { get; set; } = false;

    public ConditionBehavior(Func<BehaviorContext, bool> condition) : base()
    {
        Condition = condition;
    }

    public ConditionBehavior(Func<BehaviorContext, bool> condition, Behavior parent) : base(parent)
    {
        Condition = condition;
    }

    public override BehaviorState Evaluate(BehaviorContext context)
    {
        CurrentState = BehaviorState.Running;
        if (Condition(context))
        {
            if (Children.Count == 0)
            {
                CurrentState = BehaviorState.Success;
                return BehaviorState.Success;
            }

            if (IsSequential)
            {
                foreach (var child in Children)
                {
                    var state = child.Evaluate(context);
                    if (state == BehaviorState.Failure)
                    {
                        CurrentState = BehaviorState.Failure;
                        return BehaviorState.Failure;
                    }
                }
                CurrentState = BehaviorState.Success;
                return BehaviorState.Success;
            }
            else
            {
                foreach (var child in Children)
                {
                    var state = child.Evaluate(context);
                    if (state == BehaviorState.Success)
                    {
                        CurrentState = BehaviorState.Success;
                        return BehaviorState.Success;
                    }
                }
                CurrentState = BehaviorState.Failure;
                return BehaviorState.Failure;
            }
        }
        CurrentState = BehaviorState.Failure;
        return BehaviorState.Failure;
    }
}
