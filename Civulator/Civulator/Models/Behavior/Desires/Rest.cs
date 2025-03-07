namespace Civulator.Models.Behavior.Desires;

public class Rest(Rest.RestConfig config) : Desire("Rest", config.baseConfig)
{
    private RestConfig _config = config;

    public override void Decrease(float amount)
    {
        throw new NotImplementedException();
    }

    public override void Increase(float amount)
    {
        throw new NotImplementedException();
    }

    public override void Update()
    {
        throw new NotImplementedException();
    }

    public struct RestConfig
    {
        public DesireConfig baseConfig;
    }
}
