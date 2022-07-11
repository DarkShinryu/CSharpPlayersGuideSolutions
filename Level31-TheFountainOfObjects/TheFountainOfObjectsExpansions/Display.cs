public static class Display
{
    private static readonly ConsoleColor DefaultColor     = ConsoleColor.Gray;
    private static readonly ConsoleColor InputColor       = ConsoleColor.Cyan;
    private static readonly ConsoleColor NarrativeColor   = ConsoleColor.Green;
    private static readonly ConsoleColor DescriptionColor = ConsoleColor.White;
    private static readonly ConsoleColor EntranceColor    = ConsoleColor.Yellow;
    private static readonly ConsoleColor FountainColor    = ConsoleColor.Blue;
    private static readonly ConsoleColor ErrorColor       = ConsoleColor.Red;
    private static readonly ConsoleColor PitColor         = ConsoleColor.DarkYellow;
    private static readonly ConsoleColor MaelstromColor   = ConsoleColor.Magenta;
    private static readonly ConsoleColor AmarokColor      = ConsoleColor.DarkGreen;
    private static readonly ConsoleColor KilledColor      = ConsoleColor.DarkBlue;
    private static readonly ConsoleColor ResultColor      = ConsoleColor.DarkCyan;

    public static void Intro()
    {
        ColoredWriteLine("The Fountain of Objects\n", NarrativeColor);
        Help();
    }

    public static void Help()
    {
        ColoredWriteLine("Available commands:", EntranceColor);
        ColoredWriteLine("'Help' or 'H'", DescriptionColor);
        ColoredWriteLine("'Move North' or 'N'", DescriptionColor);
        ColoredWriteLine("'Move South' or 'S'", DescriptionColor);
        ColoredWriteLine("'Move East' or 'E'", DescriptionColor);
        ColoredWriteLine("'Move West' or 'W'", DescriptionColor);
        ColoredWriteLine("'Shoot North' or 'SN'", DescriptionColor);
        ColoredWriteLine("'Shoot South' or 'SS'", DescriptionColor);
        ColoredWriteLine("'Shoot East' or 'SE'", DescriptionColor);
        ColoredWriteLine("'Shoot West' or 'SW'", DescriptionColor);
        ColoredWriteLine("'Enable Fountain' or 'F'\n", DescriptionColor);
        ColoredWriteLine("Look out for pits. You will feel a breeze if a pit is in an adjacent room.\n" +
            "If you enter a room with a pit, you will die.\n", DescriptionColor);
        ColoredWriteLine("Maelstroms are violent forces of sentient wind.\n" +
            "Entering a room with one could transport you to any other location in the caverns.\n" +
            "You will be able to hear their growling and groaning in nearby rooms.\n", DescriptionColor);
        ColoredWriteLine("Amaroks roam the caverns. Encountering one is certain death, but you can smell their rotten stench in nearby rooms.\n", DescriptionColor);
        ColoredWriteLine("You carry with you a bow and a quiver of arrows.\n" +
            "You can use them to shoot monsters in the caverns but be warned: you have a limited supply.\n", DescriptionColor);
    }

    public static void GameStatus(Player player, Cavern cavern)     // Better to remove the +1s for debugging, obviously better for the user to not have based-0 coords
    {
        ColoredWriteLine("----------------------------------------------------------------------------------", DefaultColor);
        ColoredWriteLine($"You are in the room at (Row: {player.CurrentRoom.Row+1}/{cavern.OuterWalls.Row.Max+1}, " +
            $"Column: {player.CurrentRoom.Col+1}/{cavern.OuterWalls.Col.Max+1}).", DescriptionColor);

        if (player.IsAtEntranceRoom)
        {
            if (player.HasEnabledFountain)
                ColoredWriteLine("The Fountain of Objects has been reactivated, and you have escaped with your life!", NarrativeColor);
            else
                ColoredWriteLine("You see light coming from the cavern entrance.", EntranceColor);

            if (player.IsNearPitRoom)
                ColoredWriteLine("You feel a draft.There is a pit in a nearby room.", PitColor);
            if (player.IsNearMaelstromRoom)
                ColoredWriteLine("You hear the growling and groaning of a maelstrom nearby.", MaelstromColor);
            if (player.IsNearAmarokRoom)
                ColoredWriteLine("You can smell the rotten stench of an amarok in a nearby room.", AmarokColor);

            return;
        }
        if (player.IsAtFountainRoom)
        {
            if (player.HasEnabledFountain)
                ColoredWriteLine("You hear the rushing waters from the Fountain of Objects. It has been reactivated!", FountainColor);
            else
                ColoredWriteLine("You hear water dripping in this room. The Fountain of Objects is here!", FountainColor);

            if (player.IsNearPitRoom)
                ColoredWriteLine("You feel a draft.There is a pit in a nearby room.", PitColor);
            if (player.IsNearMaelstromRoom)
                ColoredWriteLine("You hear the growling and groaning of a maelstrom nearby.", MaelstromColor);
            if (player.IsNearAmarokRoom)
                ColoredWriteLine("You can smell the rotten stench of an amarok in a nearby room.", AmarokColor);

            return;
        }
        if (player.IsAtPitRoom)
        {
            ColoredWriteLine("You step on a bottomless pit and fall to your death.", PitColor);
            return;
        }
        if (player.IsAtMaelstromRoom)
        {
            ColoredWriteLine($"There's a maelstrom in this room. It teleported you at Row: {player.CurrentRoom.Row+1}, Col: {player.CurrentRoom.Col+1}", MaelstromColor);
            return;
        }
        if (player.IsAtAmarokRoom)
        {
            ColoredWriteLine($"There's an Amarok in this room. He eats you alive.", AmarokColor);
            return;
        }
        if (player.IsNearPitRoom || player.IsNearMaelstromRoom || player.IsNearAmarokRoom)
        {
            if (player.IsNearPitRoom)
                ColoredWriteLine("You feel a draft.There is a pit in a nearby room.", PitColor);
            if (player.IsNearMaelstromRoom)
                ColoredWriteLine("You hear the growling and groaning of a maelstrom nearby.", MaelstromColor);
            if (player.IsNearAmarokRoom)
                ColoredWriteLine("You can smell the rotten stench of an amarok in a nearby room.", AmarokColor);

            return;
        }

        ColoredWriteLine("You sense nothing, this room is empty.", DefaultColor);
    }

    public static void Result(string text)
    {
        ColoredWriteLine(text, ResultColor);
    }

    public static void PlayerPrompt(string text)
    {
        ColoredWrite(text, InputColor);
    }

    public static void KilledEnemy(string text)
    {
        ColoredWriteLine(text, KilledColor);
    }

    public static void Error(string text)
    {
        ColoredWrite(text, ErrorColor);
        Console.ReadKey(true);
        Console.WriteLine();
    }

    private static void ColoredWriteLine(string text, ConsoleColor Color)   // I wonder if there's a way to expand the Console class since static classes are sealed
    {
        Console.ForegroundColor = Color;
        Console.WriteLine(text);
        Console.ResetColor();
    }

    private static void ColoredWrite(string text, ConsoleColor Color)
    {
        Console.ForegroundColor = Color;
        Console.Write(text);
        Console.ResetColor();
    }
}