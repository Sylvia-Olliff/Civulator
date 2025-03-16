using Civulator.Engine.SimpleWorld.Environment;
using Civulator.Models.Conditions;

namespace Civulator.Engine.SimpleWorld.Map;

public struct SimpleTile(GridCoord coord)
{
    public required GridCoord Coord = coord;

    public required float Humidity = 45.0f;
    public required float Elevation = 30.0f;
    public required float Temp = 70.0f;

    public IEnumerable<ICondition> CurrentConditions = [];
    public IEnumerable<Materials> Materials = [];
    public IEnumerable<Resource> Resources = [];

    /*
     * Should track built structures and number of slots for construction
     * 
     * TODO: Add properties for list of Structures and Slots for structures
     */

    public int CurrentPop = 0;
}
