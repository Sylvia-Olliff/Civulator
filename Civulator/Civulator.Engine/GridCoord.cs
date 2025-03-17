namespace Civulator.Engine;

public struct GridCoord
{
    public required int X;
    public required int Y;

    public GridCoord Up()
    {
        Y++;
        return this;
    }

    public GridCoord Down()
    {
        Y--;
        return this;
    }

    public GridCoord Left()
    {
        X--;
        return this;
    }

    public GridCoord Right()
    {
        X++;
        return this;
    }

    public float Distance(GridCoord coord)
    {
        return MathF.Sqrt(MathF.Pow(X - coord.X, 2) + MathF.Pow(Y - coord.Y, 2));
    }
}
