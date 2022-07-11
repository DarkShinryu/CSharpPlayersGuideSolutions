public class Party
{
    public PartyType Type { get; }
    public List<Character> Characters { get; private set; }
    public Inventory Inventory { get; }
    public bool IsDefeated => Characters.Count <= 0;

    public Party(PartyType type)
    {
        Type = type;
        Characters = new List<Character>();
        Inventory = new Inventory();
    }

    public void HealParty()
    {
        foreach (Character character in Characters)
            character.Health.Current = character.Health.Max;
    }

    public void RemoveDeadCharacters()
    {
        List<Character> newCharacters = new List<Character>();

        foreach (Character character in Characters)
        {
            if (character.IsDead)
                continue;

            newCharacters.Add(character);
        }

        Characters = newCharacters;
    }

    public void SetItemsQuantities()
    {
        if (Type == PartyType.Heroes)
        {
            Inventory.Items[ItemType.Potion].Quantity = 3;
            Inventory.Items[ItemType.Elixir].Quantity = 1;

            return;
        }
        if (Characters[0] is UncodedOne)
        {
            Inventory.Items[ItemType.Elixir].Quantity = 1;

            return;
        }

        Inventory.Items[ItemType.Potion].Quantity = 1;
    }

    public void SetGearQuantities()
    {
        if (Type == PartyType.Heroes)
        {
            Inventory.Gear[GearType.Sword].InPossession = true;
            Inventory.Gear[GearType.Bow].InPossession = true;
            Inventory.Gear[GearType.Cannon].InPossession = true;

            return;
        }

        foreach (Character character in Characters)
        {
            switch (character)
            {
                case Skeleton:
                    Inventory.Gear[GearType.Dagger].InPossession = true;
                    break;
                case UncodedOne:
                    Inventory.Gear[GearType.DecodedStaff].InPossession = true;
                    break;
                default:
                    break;
            }
        }
    }
}

public enum PartyType { Heroes, Villains }