using Civulator.Models.Actions;
using Civulator.Models.Behavior;
using Civulator.Models.Conditions;

namespace Civulator.Models.Pops;

public interface IPop
{
    public string Name { get; }
    public int AgeDays { get; }

    public IAction CurrentAction { get; }
    public int CurrentActionProgress { get; }

    public ICondition CurrentCondition { get; }
    public int CurrentConditionProgress { get; }

    public IEnumerable<IAction> GetPossibleActions();

    public void Act();

    public void MakeDecision();

    public void ChangeValue(ChangeLabel changeLabel, float value);
}
