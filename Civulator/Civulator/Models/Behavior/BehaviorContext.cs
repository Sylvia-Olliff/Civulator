using Civulator.Models.Behavior.Desires;
using Civulator.Models.Pops;

namespace Civulator.Models.Behavior;

public class BehaviorContext
{
    private Dictionary<string, Desire> Desires { get; set; } = new Dictionary<string, Desire>();

    private IPop? _pop;
    public ref IPop? PopRef
    {
        get { return ref _pop; }
    }

    public BehaviorContext(IPop pop)
    {
        _pop = pop;
    }
}
