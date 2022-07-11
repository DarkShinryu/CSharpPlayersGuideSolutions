public class AttackModifier
{
    public string Name
    {
        get
        {
            return Type switch
            {
                AttackModifierType.StoneArmor => "Stone Armor",
                AttackModifierType.ObjectSight => "Object Sight",
                _ => "Unknown"
            };
        }
    }
    public int Amount
    {
        get
        {
            switch (Type)
            {
                case AttackModifierType.StoneArmor:
                    return 15;
                case AttackModifierType.ObjectSight:
                    if (Action?.Type == DamageType.Decoding)
                        return 50;
                    return 0;
                default:
                    return 0;
            }
        }
    }
    public ConsoleColor Color
    {
        get
        {
            return Type switch
            {
                AttackModifierType.StoneArmor => ConsoleColor.Yellow,
                AttackModifierType.ObjectSight => ConsoleColor.White,
                _ => ConsoleColor.Gray
            };
        }
    }
    public AttackModifierType Type { get; }
    public IAction? Action { get; set; }

    public AttackModifier(AttackModifierType type) => Type = type;
}

public enum AttackModifierType { StoneArmor, ObjectSight }