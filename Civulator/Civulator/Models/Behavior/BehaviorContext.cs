using Civulator.Models.Behavior.Desires;
using Civulator.Models.Pops;

namespace Civulator.Models.Behavior;

public class BehaviorContext
{
    public List<Desire> Desires { get; set; } = [];

    public ref IPop PopRef { get; }
}
