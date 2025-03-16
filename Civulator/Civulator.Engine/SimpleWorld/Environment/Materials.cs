using Civulator.Models.Utility;

namespace Civulator.Engine.SimpleWorld.Environment;

public class Materials : Enumeration
{

    public int Amount { get; set; }
    public float Weight { get; set; }
    public string Description { get; set; }

    public Dictionary<ResourceType, int> BuildCost { get; set; } = [];

    public float Durability { get; private set; }

    protected Materials(string name, int amount, float weight, string description, Dictionary<ResourceType, int> buildCost) : base(name)
    {
        Amount = amount;
        Weight = weight;
        Description = description;
        BuildCost = buildCost;
        Durability = 1.0f;
    }

    private Materials(string name, int amount, float weight, string description, Dictionary<ResourceType, int> buildCost, float durability) : base(name)
    {
        Amount = amount;
        Weight = weight;
        Description = description;
        BuildCost = buildCost;
        Durability = durability;
    }

    public Materials Copy()
    {
        return new Materials(this.Name, this.Amount, this.Weight, this.Description, this.BuildCost, this.Durability);
    }
}

