namespace Civulator.Models.Pops;

public struct PhysicalStats
{
    public float Temp { get; set; }

    public Attributes Stats { get; set; }

    public BodyPart Head { get; set; }
    public BodyPart Torso { get; set; }
    public BodyPart LeftArm { get; set; }
    public BodyPart RightArm { get; set; }
    public BodyPart LeftLeg { get; set; }
    public BodyPart RightLeg { get; set; }

    public PhysicalStats(Attributes stats, Func<string, Attributes, BodyPart> bodyPartFactory)
    {
        Stats = stats;
        Head = bodyPartFactory("Head", Stats);
        Torso = bodyPartFactory("Torso", Stats);
        LeftArm = bodyPartFactory("LeftArm", Stats);
        RightArm = bodyPartFactory("RightArm", Stats);
        LeftLeg = bodyPartFactory("LeftLeg", Stats);
        RightLeg = bodyPartFactory("RightLeg", Stats);
    }

    public PhysicalStats()
    {
        Stats = new Attributes
        {
            Strength = Random.Shared.Next(20, 3),
            Dexterity = Random.Shared.Next(20, 3),
            Constitution = Random.Shared.Next(20, 3),
            Intelligence = Random.Shared.Next(20, 3),
            Wisdom = Random.Shared.Next(20, 3),
            Charisma = Random.Shared.Next(20, 3)
        };

        Head = new BodyPart
        {
            Name = "Head",
            Health = 100,
            IsCritical = true
        };

        Torso = new BodyPart
        {
            Name = "Torso",
            Health = 100,
            IsCritical = true
        };

        LeftArm = new BodyPart
        {
            Name = "Left Arm",
            Health = 100,
            IsCritical = false
        };

        RightArm = new BodyPart
        {
            Name = "Right Arm",
            Health = 100,
            IsCritical = false
        };

        LeftLeg = new BodyPart
        {
            Name = "Left Leg",
            Health = 100,
            IsCritical = false
        };

        RightLeg = new BodyPart
        {
            Name = "Right Leg",
            Health = 100,
            IsCritical = false
        };
    }

    public struct BodyPart
    {
        public string Name { get; set; }
        public int Health { get; set; }

        public bool IsCritical { get; set; }
    }

    public struct Attributes
    {
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Constitution { get; set; }
        public int Intelligence { get; set; }
        public int Wisdom { get; set; }
        public int Charisma { get; set; }
    }
}
