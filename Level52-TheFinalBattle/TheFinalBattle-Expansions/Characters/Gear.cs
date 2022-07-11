public class Gear
{
    public string Name
    {
        get
        {
            return Type switch
            {
                GearType.Sword          => "Sword",
                GearType.Bow            => "Bow",
                GearType.Cannon         => "Cannon",
                GearType.BitstoneSword  => "Bitstone Sword",
                GearType.Dagger         => "Dagger",
                GearType.DecodedStaff   => "Decoded Staff",
                _                       => "Unknown"
            };
        }
    }
    public GearType Type { get; }
    public bool InPossession { get; set; }
    public bool IsEquipped { get; set; }

    public Gear(GearType type) => Type = type;
}

public enum GearType { Sword, Bow, Cannon, BitstoneSword, Dagger, DecodedStaff }