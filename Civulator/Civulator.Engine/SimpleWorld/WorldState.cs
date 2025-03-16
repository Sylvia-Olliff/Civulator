using Civulator.Models.Pops;

namespace Civulator.Engine.SimpleWorld;

public struct WorldState
{
    public required string Name;

    public List<IPop> CurrentPopulation;


}
