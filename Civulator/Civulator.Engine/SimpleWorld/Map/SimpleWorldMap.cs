using System.Collections.Concurrent;

namespace Civulator.Engine.SimpleWorld.Map;

public class SimpleWorldMap
{
    private readonly ConcurrentDictionary<GridCoord, SimpleTile> _mapGrid = [];

    private SimpleWorldMap() 
    {    
    }

    protected void AddTile(GridCoord coord, SimpleTile tile)
    {
        if (_mapGrid.ContainsKey(coord))
            return;

        _mapGrid[coord] = tile;
    }

    public void GetAllWithinDistance(GridCoord coord, float distance, out List<SimpleTile> tiles)
    {
        List<GridCoord> keys = [.. _mapGrid.Keys.Where(gcord => gcord.Distance(coord) <= distance)];
        tiles = [];

        foreach (var key in keys)
        {
            if (_mapGrid.TryGetValue(key, out SimpleTile tile))
                tiles.Add(tile);
        }
    }

    public static SimpleWorldMap GenerateMap(SimpleMapConfig config)
    {
        // TODO: Take config settings and generate the map
        // Since this is a simple World Map just randomly generate each tile. 
        var map = new SimpleWorldMap();

        for (var x = 0; x < config.MapSize.GridWidth; x++)
        {
            for (var y = 0; y < config.MapSize.GridHeight; y++)
            {
                SimpleTile newTile = new()
                {
                    Coord = new GridCoord() { X = x, Y = y },
                    Humidity = GenerateRandomValue(0.1f, 100.0f),
                    Elevation = GenerateRandomValue(-400.0f, 30000.0f),
                    Temp = GenerateRandomValue(-30.0f, 120.0f)
                };
                map.AddTile(newTile.Coord, newTile);
            }
        }
        return map;
    }

    private static float GenerateRandomValue(float min, float max)
    {
        return (float)Random.Shared.NextDouble() * (max - min) + min;
    }

    public void GetTileAt(GridCoord coord, out SimpleTile? tile)
    {
        if (_mapGrid.TryGetValue(coord, out SimpleTile result))
            tile = result;
        else
            tile = null;
        
    }

    public void UpdateTileAt(GridCoord coord, ref SimpleTile tile)
    {
        if (_mapGrid.TryGetValue(coord, out SimpleTile _))
            _mapGrid[coord] = tile;
    }
}
