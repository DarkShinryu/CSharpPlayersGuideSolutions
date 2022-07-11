Console.Title = "Packing Inventory";

Pack pack = new Pack();

while (true)
{
    Display.PackStatus(pack);
    AddItemToPack(pack);

    Display.PressKey();
    Console.ReadKey(true);
    Console.Clear();
}

// Methods
void AddItemToPack(Pack pack)
{
    InventoryItem? item;

    Display.AddItemPrompt();
    string userItemAsStr = Console.ReadLine() ?? "Unknown";

    switch (userItemAsStr.ToLower())
    {
        case "1":
        case "arrow":
            item = new Arrow();
            break;
        case "2":
        case "bow":
            item = new Bow();
            break;
        case "3":
        case "rope":
            item = new Rope();
            break;
        case "4":
        case "water":
            item = new Water();
            break;
        case "5":
        case "food":
            item = new Food();
            break;
        case "6":
        case "sword":
            item = new Sword();
            break;
        default:
            item = null;
            break;
    }

    if (item != null)
    {
        if (pack.Add(item))
            Display.AddedItem(item);
        else
            Display.NotAddedItem(item);
    }
    else
    {
        Display.NotValidItem();
    }

}