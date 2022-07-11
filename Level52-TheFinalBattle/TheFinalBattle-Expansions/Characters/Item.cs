public class Item
{
    public string Name
    {
        get
        {
            return Type switch
            {
                ItemType.Potion => "Potion",
                ItemType.Elixir => "Elixir",
                _               => "Unknown"
            };
        }
    }
    public ItemType Type { get; }
    public int Quantity { get; set; }

    public Item(ItemType type, int quantity)
    {
        Type = type;
        Quantity = quantity;
    }

    public void Use(Character target)
    {
        switch (Type)
        {
            case ItemType.Potion:
                target.Health.Current += 100;
                break;
            case ItemType.Elixir:
                target.Health.Current = target.Health.Max;
                break;
            default:
                break;
        }

        Quantity--;
    }
}

public enum ItemType { Potion, Elixir }