using R3;
using static Civulator.Models.Behavior.Desires.Desire;

namespace Civulator.Models.Behavior.Desires;

public abstract class Desire(string name, DesireConfig config)
{
    protected DesireConfig BaseConfig = config;

    public string Name { get; private set; } = name;
    public float Strength { get; set; } = config.StartingStrength;
    public float MaxStrength { get; private set; } = config.MaximumStrength;
    public float DecayRate { get; private set; } = config.DecayRate;
    public float IncreaseRate { get; private set; } = config.IncreaseRate;

    public ReactiveProperty<DesireState> State { get; protected set; } = new ReactiveProperty<DesireState>(DesireState.None);

    public virtual void Update()
    {
        if (Strength > 0 && DecayRate > 0)
        {
            Decrease(DecayRate);
        }

        if (Strength < MaxStrength && IncreaseRate > 0)
        {
            Increase(IncreaseRate);
        }

        DesireState newState = State.CurrentValue;


        if (Strength > BaseConfig.LowLevel)
            newState = DesireState.None;
        else if (Strength <= BaseConfig.LowLevel && Strength > BaseConfig.MediumLevel)
            newState = DesireState.Low;
        else if (Strength >= BaseConfig.MediumLevel)
            newState = DesireState.Medium;
        else if (Strength >= BaseConfig.HighLevel)
            newState = DesireState.High;
        else if (Strength <= BaseConfig.CriticalLevel)
            newState = DesireState.Critical;

        if (newState != State.CurrentValue)
            State.OnNext(newState);
    }

    public virtual void Increase(float amount)
    {
        if (Strength + amount > MaxStrength)
            Strength = MaxStrength;
        else
            Strength += amount;
    }

    public virtual void Decrease(float amount)
    {
        if (Strength - amount < 0)
            Strength = 0;
        else
            Strength -= amount;
    }

    public struct DesireConfig
    {
        public required float CriticalLevel;
        public required float HighLevel;
        public required float MediumLevel;
        public required float LowLevel;

        public float StartingStrength;
        public float MaximumStrength;
        public float DecayRate;
        public float IncreaseRate;
    }
}
