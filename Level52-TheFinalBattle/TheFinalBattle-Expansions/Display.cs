// Hey look, another console centric class that's totally a mess! :D
public static class Display
{
    private static Random Random = new Random();
    private static ConsoleColor IntroColor = ConsoleColor.DarkBlue;
    private static ConsoleColor ActionColor = ConsoleColor.Cyan;
    private static ConsoleColor DamageColor = ConsoleColor.Red;
    private static ConsoleColor HealColor = ConsoleColor.Green;

    public static void Intro()
    {
        Console.WriteLine("============================================================================");

        Console.ForegroundColor = IntroColor;
        Console.BackgroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\t\t\tWelcome to the final battle!".ToUpper());
        Console.ResetColor();

        Console.WriteLine("============================================================================\n");
    }

    public static void TurnInfo(Battle battle)
    {
        Console.Write($"=============================================");
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write($" BATTLE - Turn: {battle.TurnCount:00} ");
        Console.ResetColor();
        Console.WriteLine("=============================================");
        CharacterInfo(battle.Heroes);
        Console.Write("----------------------------------------------------");
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write(" VS ");
        Console.ResetColor();
        Console.WriteLine("-----------------------------------------------------");
        CharacterInfo(battle.Villains);
        Console.WriteLine("=============================================================================================================\n");
    }

    public static void TurnIntro(Character character)
    {
        Console.Write($"It is ");
        Console.ForegroundColor = character.Color;
        Console.Write($"{character.Name}");
        Console.ResetColor();
        Console.WriteLine($"'s turn...");
        Thread.Sleep(500);
    }

    public static void Taunt(Character character)
    {
        string taunt = character switch
        {
            Skeleton    => Random.Next() % 2 == 0 ? "We will repel your spineless assault!" : "Your programming skills are worthless agains us!",
            StoneAmarok => Random.Next() % 2 == 0 ? "Our defense is impenetrable!" : "You will not lay a finger on our Master!",
            BitDragon   => Random.Next() % 2 == 0 ? "I'm the guardian of the legendary Bitstone Sword!" : "I beg you, young one, free me from the Uncoded One control...",
            UncodedOne  => Random.Next() % 2 == 0 ? "The unravelling of all things is inevitable..." : "I hate programming, programmers and everyone who uses programs!",
            _           => "Hi! How did you get here?"
        };

        Console.ForegroundColor = character.Color;
        Console.WriteLine();
        Console.Write(character.Name);
        Console.ResetColor();
        Console.WriteLine($": {taunt}");
        Thread.Sleep(1000);
    }

    private static void CharacterInfo(Party party)
    {
        if (party.Type == PartyType.Villains)
        {
            foreach (Character villain in party.Characters)
            {
                Console.ForegroundColor = villain.Color;
                Console.Write($"{villain.Name}");

                if (villain.Compiled)
                {
                    for (int i = 0; i < 20 - villain.Name.Length; i++)
                        Console.Write(" ");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write($"Lv{villain.Level:00} ");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write($"(HP: {villain.Health.Current}/{villain.Health.Max}");
                    Console.Write($" | Gear: {villain.Gear?.Name ?? "None"}");
                    Console.Write(")");
                }

                Console.WriteLine();
                Console.ResetColor();
            }

            return;
        }

        foreach (Character hero in party.Characters)
        {
            Console.ForegroundColor = hero.Color;
            Console.Write($"{hero.Name}");

            if (hero.Health.Percentage <= 0.1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("!");
            }
            else if (hero.Health.Percentage <= 0.25)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("!");
            }

            Console.ResetColor();
            for (int i = 0; i < 20 - hero.Name.Length; i++)
                Console.Write(" ");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write($"Lv{hero.Level:00} ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"(HP: {hero.Health.Current}/{hero.Health.Max}");
            Console.Write($" | Gear: {hero.Gear?.Name ?? "None"}");
            Console.WriteLine(")");
            Console.ResetColor();
        }
    }

    public static void PoisonResult(Character character, int poisonDamage)
    {
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.Write($"Poison ");
        Console.ResetColor();
        Console.Write("dealt ");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write($"{poisonDamage} ");
        Console.ResetColor();
        Console.Write("damage to ");
        Console.ForegroundColor = character.Color;
        Console.WriteLine($"{character.Name}.");
        Console.ResetColor();

        Thread.Sleep(1000);

        if (character.IsDead)
        {
            Console.WriteLine();
            Console.ForegroundColor = character.Color;
            Console.Write($"{character.Name} ");
            Console.ResetColor();
            Console.WriteLine("has been defeated!");
        }
    }

    public static void TurnExecution(Character character)
    {
        if (!character.IsDead)
        {
            if (character.Action.Target == null && character.Action is not NothingAction) return;

            Console.ForegroundColor = character.Color;
            Console.Write($"{character.Name} ");
            Console.ResetColor();

            if (character.Action is NothingAction)
            {
                Console.Write("did ");
                Console.ForegroundColor = ActionColor;
                Console.WriteLine($"{character.Action.Name}.");
                Console.ResetColor();
                Thread.Sleep(1000);

                return;
            }

            if (character.Action is EquipAction)
            {
                Console.Write("equipped ");
                Console.ForegroundColor = ActionColor;
                Console.Write($"{character.Gear?.Name}");
                Console.ResetColor();
                Console.WriteLine(".");
                Thread.Sleep(1000);

                return;
            }

            if (character.Action is UnEquipAction unEquipAction)
            {
                Console.Write($"unequipped ");
                Console.ForegroundColor = ActionColor;
                Console.Write(unEquipAction.GearName);
                Console.ResetColor();
                Console.WriteLine(".");
                Thread.Sleep(1000);

                return;
            }

            Console.Write("used ");
            Console.ForegroundColor = ActionColor;
            Console.Write($"{character.Action?.Name} ");
            Console.ResetColor();
            Console.Write($"on ");
            if (character.Action?.Target != null)
            {
                Console.ForegroundColor = character.Action.Target.Color;
                Console.Write($"{character.Action.Target.Name}");
                Console.ResetColor();
                Console.WriteLine(".");

                Thread.Sleep(1000);

                ActionResult(character);
                TargetStatus(character, character.Action.Target);
            }
            Console.WriteLine();

        }
    }

    private static void ActionResult(Character character)
    {
        if (character.Action.Target != null)
        {
            if (character.Action.Target.AttackModifier != null)
            {
                if ((character.Action.Target.AttackModifier.Type == AttackModifierType.ObjectSight && character.Action.Type == DamageType.Normal) || character.Action is CompileAction || character.Action is ItemAction)
                {
                    // Do nothing
                }
                else if (character.Action.Success)
                {
                    Console.ForegroundColor = character.Action.Target.AttackModifier.Color;
                    Console.Write($"{character.Action.Target.AttackModifier.Name} ");
                    Console.ResetColor();
                    Console.Write("reduced the attack by ");
                    Console.ForegroundColor = DamageColor;
                    Console.Write($"{character.Action.Target.AttackModifier.Amount} ");
                    Console.ResetColor();
                    Console.WriteLine("point/s.");
                    Thread.Sleep(1000);
                }
            }

            if (character.Action is CompileAction)
            {
                Console.ForegroundColor = character.Action.Target.Color;
                Console.Write($"{character.Action.Target.Name}");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write($" Lv{character.Action.Target.Level} ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($"(HP: {character.Action.Target.Health.Current}/{character.Action.Target.Health.Max}");
                Console.Write($" | Gear: {character.Action.Target.Gear?.Name ?? "None"}");
                Console.WriteLine(")");
                Console.ResetColor();
                Thread.Sleep(1000);

                return;
            }

            Console.ForegroundColor = ActionColor;
            Console.Write($"{character.Action?.Name} ");
            Console.ResetColor();

            if (character.Action != null && !character.Action.Success)
            {
                Console.WriteLine("missed.");
                Thread.Sleep(1000);

                return;
            }

            if (character.Action is ItemAction itemAction)
            {
                switch (itemAction.Item?.Type)
                {
                    case ItemType.Potion:
                        Console.Write("healed ");
                        Console.ForegroundColor = HealColor;
                        Console.Write($"100 ");
                        Console.ResetColor();
                        Console.Write($"HP to ");
                        break;
                    case ItemType.Elixir:
                        Console.Write("healed ");
                        Console.ForegroundColor = HealColor;
                        Console.Write($"ALL ");
                        Console.ResetColor();
                        Console.Write($"HP to ");
                        break;
                    default:
                        break;
                }
            }
            else
            {
                Console.Write("dealt ");
                Console.ForegroundColor = DamageColor;

                if (character.Action is PunchAction punchAction) Console.Write($"{punchAction.Damage} ");
                else if (character.Action is BoneCrunchAction boneCrunchAction) Console.Write($"{boneCrunchAction.Damage} ");
                else if (character.Action is BiteAction biteAction) Console.Write($"{biteAction.Damage} ");
                else if (character.Action is ClawAction clawAction) Console.Write($"{clawAction.Damage} ");
                else if (character.Action is UnravelingAction unravelingAction) Console.Write($"{unravelingAction.Damage} ");
                Console.ResetColor();
                Console.Write("damage to ");
            }

            if (character.Action != null)
            {
                Console.ForegroundColor = character.Action.Target.Color;
                Console.Write($"{character.Action.Target.Name}");
            }

            Console.ResetColor();
            Console.WriteLine(".");

            if (character.Action is PoisonShotAction)
            {
                Console.ForegroundColor = character.Action.Target.Color;
                Console.Write($"{character.Action.Target} ");
                Console.ResetColor();
                Console.WriteLine("has been poisoned.");
            }

            if (character.Action is UncodedJudgmentAction)
            {
                Console.ForegroundColor = ActionColor;
                Console.Write($"{character.Action.Name} ");
                Console.ResetColor();
                Console.WriteLine("destroys the Uncoded One's Decoded Staff!");
            }

            Thread.Sleep(1000);
        }
    }

    private static void TargetStatus(Character attacker, Character target)
    {
        if (attacker.Action.Success && target.Compiled && attacker.Action is not CompileAction)
        {
            Console.ForegroundColor = target.Color;
            Console.Write($"{target.Name} ");
            Console.ResetColor();
            Console.WriteLine($"is now at {target.Health.Current}/{target.Health.Max} HP.");
            Thread.Sleep(1000);
        }

        if (target.IsDead)
        {
            Console.WriteLine();
            Console.ForegroundColor = target.Color;
            Console.Write($"{target.Name} ");
            Console.ResetColor();
            Console.WriteLine("has been defeated!");
        }
    }

    public static void BattleResult(Battle battle)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Battle Result\n");
        Thread.Sleep(1000);

        Console.ResetColor();
        Console.WriteLine($"Total Turns: {battle.TurnCount}");
        Thread.Sleep(500);
        Console.WriteLine($"Battle Duration: {battle.Duration.Minutes:00}m:{battle.Duration.Seconds:00}s");
        Thread.Sleep(500);
        Console.Write($"Winner: ");
        Console.WriteLine(battle.Villains.IsDefeated ? battle.Heroes.Type : battle.Villains.Type);
        Thread.Sleep(500);
        Console.WriteLine("Experience: " + battle.TotalBattleExperience);
        Thread.Sleep(500);
        Loot(battle.Loot);
        Thread.Sleep(500);
        Console.Write("\nPress a key to continue...");
        Console.ReadKey(true);
        Console.Clear();
    }

    public static void GameResult(Party heroes, Party villains)
    {
        Console.WriteLine(!heroes.IsDefeated && villains.IsDefeated ?
            "You have defeated the Uncoded One!\nPeace has finally returned to the Realms of C#!" :
            "The Uncoded one and his minions have defeated you.\nThere is no hope left for the Realms of C#...");
    }

    private static void Loot(Inventory loot)
    {
        if (!loot.ItemsIsEmpty)
        {
            Console.Write("Items: ");
            foreach (Item item in loot.Items.Values)
            {
                for (int i = 0; i < item.Quantity; i++)
                    Console.Write($"{item.Name} ");
            }

            Console.WriteLine();
        }

        if (!loot.GearIsEmpty)
        {
            Console.Write("Gear: ");
            foreach (Gear gear in loot.Gear.Values)
            {
                if (gear.InPossession)
                    Console.Write($"{gear.Name} ");
            }

            Console.WriteLine();
        }
    }
}