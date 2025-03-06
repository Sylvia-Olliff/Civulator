using Civulator.Models.Behavior.Nodes;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Civulator.Models.Behavior;

public class BehaviorBuilder
{
    private Behavior? Root { get; set; }

    public BehaviorBuilder GenerateBaseBehavior()
    {
        Root = new SequencerBehavior();
        AddHungerBehavior();


        return this;
    }

    private void AddHungerBehavior()
    {
        var hungerBehavior = new SelectorBehavior();
        hungerBehavior.Children.Add(new ConditionBehavior((context) => (int)context["hunger"] < 50));
        hungerBehavior.Children.Add(new ActionBehavior((context) =>
        {
            context["hunger"] = 100;
            return BehaviorState.Success;
        }));
        Root?.Children.Add(hungerBehavior);
    }
}
