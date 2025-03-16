namespace Civulator.Engine.SimpleWorld.Map;

public struct SimpleMapConfig(SimpleMapSize size, string name, int startingPop, float seaLevel = 20.0f, float startingElevation = 50.0f)
{
    public required SimpleMapSize MapSize = size;

    public required string MapLabel = name;

    public required int StartingPopulation = startingPop;

    public float SeaLevel = seaLevel;

    public float StartingElevation = startingElevation;
}

