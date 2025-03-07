namespace Civulator.Models.Behavior.Desires;

public class Hunger : Desire
{
    public Hunger() : base("Hunger", 50.0f, 200.0f, 0.5f, 0.0f)
    {
    }

    public Hunger(float strength, float maxStrength, float decayRate, float increaseRate) : base("Hunger", strength, maxStrength, decayRate, increaseRate)
    {
    }

    private bool _hasChanged = false;

    public override void Update()
    {
        if (Strength > 0 && DecayRate > 0)
        {
            Decrease(DecayRate);
        }

        if (Strength < MaxStrength && IncreaseRate > 0)
        {
            Increase(IncreaseRate);
        }

        if (Strength > 125)
            State = DesireState.None;
        else if (Strength > 100)
            State = DesireState.Low;
        else if (Strength > 75)
            State = DesireState.Medium;
        else if (Strength > 50)
            State = DesireState.High;
        else if (Strength <= 25)
            State = DesireState.Critical;

        Notify();
    }

    private void Notify()
    {
        if (_observers.Count == 0)
        {
            return;
        }

        if (Strength == 0)
        {
            foreach (var observer in _observers)
            {
                observer.OnCompleted();
            }
            return;
        }

        if (_hasChanged) 
        {
            foreach (var observer in _observers)
            {
                observer.OnNext(this);
            }
        }
        _hasChanged = false;
    }
    public override void Increase(float amount)
    {
        if (Strength + amount > MaxStrength)
        {
            Strength = MaxStrength;
        }
        else
        {
            _hasChanged = true;
            Strength += amount;
        }
    }
    public override void Decrease(float amount)
    {
        if (Strength - amount < 0)
        {
            Strength = 0;
        }
        else
        {
            _hasChanged = true;
            Strength -= amount;
        }
    }
}
