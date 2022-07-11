public class Inventory
{
    public Dictionary<ItemType, Item> Items { get; }
    public Dictionary<GearType, Gear> Gear { get; }
    public bool ItemsIsEmpty
    {
        get
        {
            bool isEmpty = true;

            foreach (Item item in Items.Values)
                if (item.Quantity > 0) { isEmpty = false; break; }

            return isEmpty;
        }
    }
    public bool GearIsEmpty
    {
        get
        {
            bool isEmpty = true;

            foreach (Gear gear in Gear.Values)
                if (gear.InPossession) { isEmpty = false; break; }

            return isEmpty;
        }
    }

    public Inventory()
    {
        Items = new Dictionary<ItemType, Item>();
        Gear = new Dictionary<GearType, Gear>();

        GenerateItems();
        GenerateGear();
    }

    public void GenerateItems()
    {
        foreach (ItemType itemType in Enum.GetValues(typeof(ItemType)))
            Items.Add(itemType, new Item(itemType, 0));
    }

    public void GenerateGear()
    {
        foreach (GearType gearType in Enum.GetValues(typeof(GearType)))
            Gear.Add(gearType, new Gear(gearType));
    }
}