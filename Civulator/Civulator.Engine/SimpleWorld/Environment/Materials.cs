using Civulator.Engine.SimpleWorld.Environment.Resources;
using Civulator.Models.Utility;
using System.Runtime.CompilerServices;

namespace Civulator.Engine.SimpleWorld.Environment;

public class Materials : Enumeration
{
    public readonly static Materials LumberTemplate = new("Lumber", 2, 1.0f, "A shaped piece of wood.", 
        new Recipe { 
            ResultAmount = 2, 
            Ingrediants = [ 
                new Recipe.Ingrediant { 
                    Amount = 1, 
                    Optional = false, 
                    ResType = ResourceType.Wood 
                }
            ] 
        });
    public readonly static Materials StoneBlockTemplate = new("StoneBlock", 1, 1.0f, "A shaped piece of stone.", 
        new Recipe
        {
            ResultAmount = 1,
            Ingrediants = [
                new Recipe.Ingrediant
                {
                    Amount = 1,
                    Optional = false,
                    ResType = ResourceType.Stone
                }
            ]
        });
    public readonly static Materials MetalIngotTemplate = new("MetalIngot", 1, 1.0f, "A shaped piece of metal.", 
        new Recipe
        {
            ResultAmount = 1,
            Ingrediants = [
                new Recipe.Ingrediant
                {
                    Amount = 2,
                    Optional = false,
                    ResType = ResourceType.Ore
                }
            ]
        });
    public readonly static Materials LeatherTemplate = new("Leather", 2, 1.0f, "A shaped piece of leather.", 
        new Recipe { 
            ResultAmount = 1, 
            Ingrediants = [
                new Recipe.Ingrediant 
                { 
                    Amount = 1, 
                    Optional = false, 
                    ResType = ResourceType.AnimalHide 
                }
            ] 
        });
    public readonly static Materials PreparedVegetablesTemplate = new("PreparedVegetables", 1, 1.0f, "A handful of prepared vegetables.", 
        new Recipe { 
            ResultAmount = 1, 
            Ingrediants = [
                new Recipe.Ingrediant 
                { 
                    Amount = 1,
                    Optional = false, 
                    ResType = ResourceType.Plants 
                },
                new Recipe.Ingrediant
                {
                    Amount = 1,
                    Optional = false,
                    ResType = ResourceType.Plants
                }
            ] 
        });

    public int Amount { get; set; }
    public float Weight { get; set; }
    public string Description { get; set; }

    public Recipe Recipe { get; private set; }

    public float Durability { get; set; }

    protected Materials(string name, int amount, float weight, string description, Recipe recipe) : base(name)
    {
        Amount = amount;
        Weight = weight;
        Description = description;
        Recipe = recipe;
        Durability = 1.0f;
    }

    private Materials(string name, int amount, float weight, string description, Recipe recipe, float durability) : base(name)
    {
        Amount = amount;
        Weight = weight;
        Description = description;
        Recipe = recipe;
        Durability = durability;
    }

    public Materials Copy()
    {
        return new Materials(this.Name, this.Amount, this.Weight, this.Description, this.Recipe, this.Durability);
    }
}

