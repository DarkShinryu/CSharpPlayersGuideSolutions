// Hey look, another console centric class that's totally a mess! :D
public static class Display
{
    private static ConsoleColor IntroColor = ConsoleColor.DarkBlue;
    private static ConsoleColor ActionColor = ConsoleColor.Cyan;
    private static ConsoleColor DamageColor = ConsoleColor.Red;

    public static void Intro()
    {
        Console.WriteLine("=============================================================");

        Console.ForegroundColor = IntroColor;
        Console.BackgroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\t\tWelcome to the final battle!".ToUpper());
        Console.ResetColor();

        Console.WriteLine("=============================================================\n");
    }

    public static void TurnInfo(Battle battle)
    {
        Console.WriteLine($"Turn: {battle.TurnCount}");
        CharacterInfo(battle.Heroes);
        Console.Write(" || ");
        CharacterInfo(battle.Villains);
        Console.WriteLine('\n');
    }

    private static void CharacterInfo(Party party)
    {
        for (int i = 0; i < party.Characters.Count; i++)
        {
            if (i != 0) Console.Write($" | ");

            Console.ForegroundColor = party.Characters[i].Color;
            Console.Write($"{party.Characters[i].Name}: ");
            Console.ResetColor();
            Console.Write($"HP {party.Characters[i].Health.Current}/{party.Characters[i].Health.Max}");
        }
    }

    public static void TurnIntro(Character character)
    {
        Console.Write($"It is ");
        Console.ForegroundColor = character.Color;
        Console.Write($"{character.Name}");
        Console.ResetColor();
        Console.WriteLine($"'s turn...");
    }

    public static void TurnExecution(Character character, Character? target)
    {
        if (target == null && character.Action is not NothingAction) return;

        Console.ForegroundColor = character.Color;
        Console.Write($"{character.Name} ");
        Console.ResetColor();

        if (character.Action is NothingAction)
        {
            Console.Write("did ");
            Console.ForegroundColor = ActionColor;
            Console.WriteLine($"{character.Action.Name}.");
            Console.ResetColor();

            return;
        }

        Console.Write("used ");
        Console.ForegroundColor = ActionColor;
        Console.Write($"{character.Action.Name} ");
        Console.ResetColor();
        Console.Write($"on ");
        if (target != null)
        {
            Console.ForegroundColor = target.Color;
            Console.Write($"{target.Name}");
            Console.ResetColor();
            Console.WriteLine(".");

            ActionResult(character, target);
            TargetStatus(target);
        }
    }

    private static void ActionResult(Character character, Character target)
    {
        Console.ForegroundColor = ActionColor;
        Console.Write($"{character.Action.Name} ");
        Console.ResetColor();
        Console.Write("dealt ");
        Console.ForegroundColor = DamageColor;
        Console.Write($"{character.Action.Damage} ");
        Console.ResetColor();
        Console.Write("damage to ");
        Console.ForegroundColor = target.Color;
        Console.Write($"{target.Name}");
        Console.ResetColor();
        Console.WriteLine(".");
    }

    private static void TargetStatus(Character target)
    {
        Console.ForegroundColor = target.Color;
        Console.Write($"{target.Name} ");
        Console.ResetColor();
        Console.WriteLine($"is now at {target.Health.Current}/{target.Health.Max} HP.");

        if (target.IsDead)
        {
            Console.ForegroundColor = target.Color;
            Console.Write($"{target.Name} ");
            Console.ResetColor();
            Console.WriteLine("has been defeated!");
        }
    }

    public static void BattleResult(Battle battle)
    {
        Console.WriteLine("Battle Result\n");

        Console.WriteLine($"Total Turns: {battle.TurnCount}");
        Console.WriteLine($"Battle Duration: {battle.Duration.Minutes:00}m:{battle.Duration.Seconds:00}s");
        Console.Write($"Winner: ");
        Console.WriteLine(battle.Villains.Defeated ? battle.Heroes.Name : battle.Villains.Name);

        Console.Write("\nPress a key to continue...");
        Console.ReadKey(true);
        Console.Clear();
    }

    public static void GameResult(Party heroes, Party villains)
    {
        Console.WriteLine(!heroes.Defeated && villains.Defeated ? 
            "You have defeated the Uncoded One!\nPeace has finally returned to the Realms of C#!" : 
            "The Uncoded one and his minions have defeated you.\nThere is no hope left for the Realms of C#...");
    }
}