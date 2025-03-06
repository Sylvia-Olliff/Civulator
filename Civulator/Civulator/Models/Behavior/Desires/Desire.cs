namespace Civulator.Models.Behavior.Desires;

public abstract class Desire
{
    public string Name { get; private set; } = "";
    public float Strength { get; set; } = 0.0f;
    public float StartingStrength { get; private set; } = 0.0f;
    public float MaxStrength { get; private set; } = 100.0f;
    public float DecayRate { get; private set; } = 0.0f;
    public float IncreaseRate { get; private set; } = 0.0f;

    public Desire(string name, float strength, float decayRate, float increaseRate)
    {
        Name = name;
        Strength = strength;
        StartingStrength = strength;
        DecayRate = decayRate;
        IncreaseRate = increaseRate;
    }

    public void Update()
    {
        Strength = Math.Max(0.0f, Strength - DecayRate);
    }

    public void Increase(float amount)
    {
        if (Strength + amount > MaxStrength)
        {
            Strength = MaxStrength;
            return;
        }
        Strength = Math.Min(StartingStrength, Strength + amount);
    }
}
