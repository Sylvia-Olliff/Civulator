using System.Collections.Concurrent;

namespace Civulator.Engine.SimpleWorld.Map;

public class SimpleWorldMap
{
    private ConcurrentDictionary<GridCoord, SimpleTile> _mapGrid = [];

    private SimpleWorldMap() 
    {    
    }

    protected void AddTile(GridCoord coord, SimpleTile tile)
    {
        if (_mapGrid.ContainsKey(coord))
            return;

        _mapGrid[coord] = tile;
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
                    Humidity = (float)Random.Shared.NextDouble() * 100,
                    Elevation = 100.0f,
                    Temp = 80.0f
                };
                map.AddTile(newTile.Coord, newTile);
            }
        }
        return map;
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
        if (_mapGrid.TryGetValue(coord, out SimpleTile local))
            _mapGrid[coord] = tile;
    }
}
