using static Civulator.Models.Behavior.Desires.Safety;

namespace Civulator.Models.Behavior.Desires;

public class Safety(SafetyConfig config) : Desire("Safety", config.baseConfig)
{
    public struct SafetyConfig
    {
        public DesireConfig baseConfig;

        public SafetyConfig()
        {
            baseConfig = new DesireConfig
            {
                StartingStrength = 10.0f,
                MaximumStrength = 200.0f,
                DecayRate = 0.0f,
                IncreaseRate = 0.0f,

                CriticalLevel = 25,
                HighLevel = 50,
                MediumLevel = 75,
                LowLevel = 100
            };
        }
    }
}
