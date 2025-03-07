namespace Civulator.Models.Behavior.Desires;

public abstract class Desire(string name, float strength, float maxStrength, float decayRate, float increaseRate)
{
    public string Name { get; private set; } = name;
    public float Strength { get; set; } = strength;
    public float MaxStrength { get; private set; } = maxStrength;
    public float DecayRate { get; private set; } = decayRate;
    public float IncreaseRate { get; private set; } = increaseRate;

    public DesireState State { get; protected set; } = DesireState.None;

    protected readonly List<IObserver<Desire>> _observers = [];

    public abstract void Update();

    public abstract void Increase(float amount);

    public abstract void Decrease(float amount);

    public void Attach(IObserver<Desire> observer)
    {
        _observers.Add(observer);
    }

    public void Detach(IObserver<Desire> observer)
    {
        _observers.Remove(observer);
    }

    public void ClearObservers()
    {
        _observers.Clear();
    }
}
