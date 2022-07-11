public class Pack
{
    // Properties
    public InventoryItem[] Items { get; }
    public int MaxItemsCount { get; }
    public float MaxWeight { get; }
    public float MaxVolume { get; }
    public float ItemsCount
    {
        get
        {
            int value = 0;
            foreach (InventoryItem item in Items)
            {
                if (item != null)
                    value++;
            }

            return value;
        }
    }
    public float Weight
    {
        get
        {
            float value = 0f;
            foreach (InventoryItem item in Items)
            {
                if (item != null)
                    value += item.Weight;
            }

            return value;
        }
    }
    public float Volume
    {
        get
        {
            float value = 0f;
            foreach (InventoryItem item in Items)
            {
                if (item != null)
                    value += item.Volume;
            }

            return value;
        }
    }


    // Constructors
    public Pack()
    {
        MaxWeight = 20f;
        MaxVolume = 10f;
        MaxItemsCount = 8;
        Items = new InventoryItem[MaxItemsCount];
    }


    // Methods
    public bool Add(InventoryItem item)
    {
        bool isSpaceAvailable = ItemsCount < MaxItemsCount;
        bool isWeightAvailable = Weight + item.Weight <= MaxWeight;
        bool isVolumeAvailable = Volume + item.Volume <= MaxVolume;

        if (isSpaceAvailable && isWeightAvailable && isVolumeAvailable)
        {
            for (int i = 0; i < Items.Length; i++)
            {
                if (Items[i] == null)
                {
                    Items[i] = item;
                    return true;
                }
            }
        }

        return false;
    }

    public override string ToString()
    {
        if (Items[0] == null)
            return "This pack is empty.";

        string value = "Pack containg: ";
        foreach (InventoryItem item in Items)
        {
            if (item != null)
                value += item.ToString() + ", ";
        }
        value = value.Remove(value.Length - 2) + '.'; // Removing the last space + comma and adding a period

        return value;
    }
}
