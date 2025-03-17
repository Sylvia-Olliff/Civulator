using Civulator.Models.Utility;

namespace Civulator.Engine.SimpleWorld.Environment;

public class Resource : Enumeration
{
    // Wood
    public static readonly Resource PineTemplate            = new("Pine", 0, 5.5f, "A piece of uncut Pine. A log", ResourceType.Wood, 1.5f);
    public static readonly Resource OakTemplate             = new("Oak", 0, 6.2f, "A piece of uncut Oak. A log", ResourceType.Wood, 2.5f);
    public static readonly Resource FirTemplate             = new("Fir", 0, 5.7f, "A piece of uncut Fir. A log", ResourceType.Wood, 2.1f);

    // Ore
    public static readonly Resource TinOreTemplate          = new("TinOre", 0, 1.0f, "A kilogram of Tin Ore", ResourceType.Ore, 2.0f);
    public static readonly Resource CopperOreTemplate       = new("CopperOre", 0, 1.0f, "A kilogram of Copper Ore", ResourceType.Ore, 2.2f);
    public static readonly Resource IronOreTemplate         = new("IronOre", 0, 1.0f, "A kilogram of Iron Ore", ResourceType.Ore, 3.0f);

    // Food
    public static readonly Resource BerriesTemplate         = new("Berries", 0, 0.1f, "A handful of berries", ResourceType.Food);
    public static readonly Resource VegetablesTemplate      = new("Vegetables", 0, 0.5f, "A handful of vegetables", ResourceType.Food);
    public static readonly Resource FruitTemplate           = new("Fruits", 0, 0.2f, "A handful of fruit", ResourceType.Food);

    // Water
    public static readonly Resource DrinkingWaterTemplate   = new("DrinkingWater", 0, 1.0f, "A single litre of drinkable water", ResourceType.Water);

    public int Amount { get; set; }
    public float Weight { get; set; }
    public ResourceType Type { get; set; }
    public string Description { get; set; }
    public float? Durability { get; set; }

    protected Resource(string name, int amount, float weight, string description, ResourceType type, float? durability = null) : base(name)
    {
        Amount = amount;
        Weight = weight;
        Type = type;
        Description = description;
        Type = type;
        Durability = durability;
    }

    public Resource Copy()
    {
        return new Resource(this.Name, this.Amount, this.Weight, this.Description, this.Type, this.Durability);
    }
}

