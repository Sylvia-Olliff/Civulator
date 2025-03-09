using Civulator.Models.Behavior.Desires;
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
        hungerBehavior.Children.Add(new ConditionBehavior((context) => context.Desires.Single(d => d.Name == "Hunger").State.CurrentValue is DesireState.None) 
        { 
            Children = []
        });
        
        
        Root?.Children.Add(hungerBehavior);
    }
}
