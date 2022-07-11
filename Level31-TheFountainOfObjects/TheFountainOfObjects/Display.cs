public static class Display
{
    private static readonly ConsoleColor DefaultColor     = ConsoleColor.Gray;
    private static readonly ConsoleColor InputColor       = ConsoleColor.Cyan;
    private static readonly ConsoleColor NarrativeColor   = ConsoleColor.Green;
    private static readonly ConsoleColor DescriptionColor = ConsoleColor.White;
    private static readonly ConsoleColor EntranceColor    = ConsoleColor.Yellow;
    private static readonly ConsoleColor FountainColor    = ConsoleColor.Blue;
    private static readonly ConsoleColor ErrorColor       = ConsoleColor.Red;
    private static readonly ConsoleColor WinColor         = ConsoleColor.DarkCyan;

    public static void Intro()
    {
        ColoredWriteLine("The Fountain of Objects\n", NarrativeColor);
        ColoredWriteLine("Available commands:", EntranceColor);
        ColoredWriteLine("'Move North' or 'N'", DescriptionColor);
        ColoredWriteLine("'Move South' or 'S'", DescriptionColor);
        ColoredWriteLine("'Move East' or 'E'", DescriptionColor);
        ColoredWriteLine("'Move West' or 'W'", DescriptionColor);
        ColoredWriteLine("'Enable Fountain' or 'F'\n\n\n", DescriptionColor);
    }

    public static void GameStatus(Player player)
    {
        ColoredWriteLine("----------------------------------------------------------------------------------", DefaultColor);
        ColoredWriteLine($"You are in the room at (Row = {player.CurrentPos.Row}, Column = {player.CurrentPos.Col}).", DescriptionColor);

        if (player.IsAtEntranceRoom)
        {
            if (player.HasEnabledFountain)
                ColoredWriteLine("The Fountain of Objects has been reactivated, and you have escaped with your life!", NarrativeColor);
            else
                ColoredWriteLine("You see light coming from the cavern entrance.", EntranceColor);

            return;
        }
        if (player.IsAtFountainRoom)
        {
            if (player.HasEnabledFountain)
                ColoredWriteLine("You hear the rushing waters from the Fountain of Objects. It has been reactivated!", FountainColor);
            else
                ColoredWriteLine("You hear water dripping in this room. The Fountain of Objects is here!", FountainColor);

            return;
        }

        ColoredWriteLine("You sense nothing, this room is empty.", DefaultColor);
    }

    public static void Win()
    {
        ColoredWriteLine("You win!", WinColor);
        PlayVictoryMusic();
    }

    public static void PlayerPrompt(string text)
    {
        ColoredWrite(text, InputColor);
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

    private static void PlayVictoryMusic()
    {
        // Durations are good enough approximations
        Beep(587, 200);
        Beep(587, 200);
        Beep(587, 200);
        Beep(587, 800);
        Beep(466, 500);
        Beep(523, 500);
        Beep(587, 500);
        Beep(523, 300);
        Beep(587, 1200);
    }

    private static void Beep(int frequency, int duration)
    {
        if (frequency > 0)
            Console.Beep(frequency, duration);
        else
            Thread.Sleep(duration);
    }
}