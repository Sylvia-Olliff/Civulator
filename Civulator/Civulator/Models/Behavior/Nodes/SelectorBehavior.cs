namespace Civulator.Models.Behavior.Nodes;

public class SelectorBehavior : Behavior
{
    public SelectorBehavior() { }
    public SelectorBehavior(Behavior parent) : base(parent) { }

    public override BehaviorState Evaluate(BehaviorContext context)
    {
        CurrentState = BehaviorState.Running;
        if (Children.Count == 0)
        {
            CurrentState = BehaviorState.Success;
            return BehaviorState.Success;
        }
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
