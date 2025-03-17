namespace Civulator.Engine.SimpleWorld.Environment.Resources;

public readonly struct Recipe(string materialName, short resultAmount, Recipe.Ingrediant[] ingrediants)
{
    public Materials Result { get; init; } = Materials.GetAll<Materials>().Where(material => material.Name == materialName).First();
    public short ResultAmount { get; init; } = resultAmount;

    public Ingrediant[] Ingrediants { get; init; } = ingrediants;

    public readonly struct Ingrediant
    {
        public readonly bool Optional { get; init; }
        public readonly ResourceType ResType { get; init; }
        public readonly Resource? RequiredResource { get; init; }
        public readonly short Amount { get; init; }
    }
}
