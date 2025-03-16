namespace Civulator.Models.Behavior.Desires;

public class Hunger(Hunger.HungerConfig config) : Desire("Hunger", config.baseConfig)
{
    public struct HungerConfig
    {
        public DesireConfig baseConfig;

        public HungerConfig()
        {
            baseConfig = new DesireConfig
            {
                StartingStrength = 50.0f,
                MaximumStrength = 200.0f,
                DecayRate = 0.5f,
                IncreaseRate = 0.0f,

                CriticalLevel = 25,
                HighLevel = 50,
                MediumLevel = 75,
                LowLevel = 100
            };
        }
    }
}
