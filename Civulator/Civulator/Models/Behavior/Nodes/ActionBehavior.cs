namespace Civulator.Models.Behavior.Nodes;

public class ActionBehavior : Behavior
{
    private Func<BehaviorContext, BehaviorState> Action { get; set; }
    public ActionBehavior(Func<BehaviorContext, BehaviorState> action) : base()
    {
        Action = action;
    }
    public ActionBehavior(Func<BehaviorContext, BehaviorState> action, Behavior parent) : base(parent)
    {
        Action = action;
    }
    public override BehaviorState Evaluate(BehaviorContext context)
    {
        CurrentState = Action(context);
        return CurrentState;
    }
}
