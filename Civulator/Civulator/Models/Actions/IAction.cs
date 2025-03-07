using Civulator.Models.Conditions;

namespace Civulator.Models.Actions;

public interface IAction
{
    public string Name { get; }
    public int Duration { get; }
    public List<ICondition> PossibleConditions { get; }
    public List<ICondition> RequiredConditions { get; }

    public ActionResult ActionResult { get; }
}
