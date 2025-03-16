using Civulator.Models.Utility;

namespace Civulator.Engine.SimpleWorld.Map;

public class SimpleMapSize : Enumeration
{
    public static readonly SimpleMapSize Small = new(1, "Small", 100, 100);
    public static readonly SimpleMapSize Medium = new(2, "Medium", 300, 300);
    public static readonly SimpleMapSize Large = new(3, "Large", 800, 800);
    public static readonly SimpleMapSize Huge = new(4, "Huge", 1200, 1200);
    
    public int GridWidth { get; private set; }
    public int GridHeight { get; private set; }

    protected SimpleMapSize(int id, string name, int gridWidth, int gridHeight) : base(id, name)
    {
        GridWidth = gridWidth;
        GridHeight = gridHeight;
    }
}

