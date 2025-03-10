﻿namespace Civulator.Models.Behavior.Desires;

public class Rest(Rest.RestConfig config) : Desire("Rest", config.baseConfig)
{
    public struct RestConfig
    {
        public DesireConfig baseConfig;

        public RestConfig()
        {
            baseConfig = new DesireConfig
            {
                StartingStrength = 50.0f,
                MaximumStrength = 200.0f,
                DecayRate = 1f,
                IncreaseRate = 0.0f,

                CriticalLevel = 25,
                HighLevel = 50,
                MediumLevel = 75,
                LowLevel = 100
            };
        }
    }
}
