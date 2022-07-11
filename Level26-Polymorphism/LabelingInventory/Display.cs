public static class Display
{
    public static void PackStatus(Pack pack)    // Let's make it pretty!
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("+--------------------------------------------------+");
        Console.Write("| ");
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("Pack Status");
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("                                      |"); // It's the right amount of white space, don't worry about it... :P
        Console.Write("| ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write($"Items: {pack.ItemsCount}/{pack.MaxItemsCount} | Weight: {pack.Weight,5:0.00}/{pack.MaxWeight} | Volume: {pack.Volume,5:0.00}/{pack.MaxVolume}");
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(" |");
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("+--------------------------------------------------+");
        Console.ResetColor();
    }

    public static void AddItemPrompt()
    {
        Console.WriteLine();
        Console.WriteLine(
            "1. Arrow\n" +
            "2. Bow\n" +
            "3. Rope\n" +
            "4. Water\n" +
            "5. Food\n" +
            "6. Sword");

        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("Enter an item to add: ");
        Console.ResetColor();
    }

    public static void AddedItem(InventoryItem item)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"\n{item} added to the pack.\n\n\n");
        Console.ResetColor();
    }

    public static void NotAddedItem(InventoryItem item)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"\n{item} not added to the pack, not enough space.\n\n\n");
        Console.ResetColor();
    }

    public static void NotValidItem()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("\nThat's not a valid item.\n\n\n");
        Console.ResetColor();
    }

    public static void PressKey()
    {
        Console.Write("Press a key to continue...");
    }
}