namespace Civulator.Models.Behavior;

public abstract class Behavior
{
    public List<Behavior> Children { get; set; } = [];
    public Behavior? Parent { get; set; } = null;
    public BehaviorState CurrentState { get; set; } = BehaviorState.Idle;

    public bool IsRoot => Parent == null;
    public bool IsLeaf => Children.Count == 0;
    public abstract BehaviorState Evaluate(BehaviorContext context);

    public Behavior(Behavior parent)
    {
        Parent = parent;
    }
    public Behavior() { }
}
