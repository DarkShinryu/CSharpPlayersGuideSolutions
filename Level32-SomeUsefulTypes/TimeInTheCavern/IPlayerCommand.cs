public interface IPlayerCommand
{
    public void Execute(Player player, Cavern cavern); // I need the cavern for the walls and fountain room positions
}

public class NorthCommand : IPlayerCommand
{
    public void Execute(Player player, Cavern cavern)
    {
        if (player.CurrentRoom.Row > cavern.OuterWalls.Row.Min)
            player.CurrentRoom = new Room(player.CurrentRoom.Row - 1, player.CurrentRoom.Col);
        else
            Display.Error("There's a wall over there, press a key to continue...");
    }
}

public class SouthCommand : IPlayerCommand
{
    public void Execute(Player player, Cavern cavern)
    {
        if (player.CurrentRoom.Row < cavern.OuterWalls.Row.Max)
            player.CurrentRoom = new Room(player.CurrentRoom.Row + 1, player.CurrentRoom.Col);
        else
            Display.Error("There's a wall over there, press a key to continue...");
    }
}

public class WestCommand : IPlayerCommand
{
    public void Execute(Player player, Cavern cavern)
    {
        if (player.CurrentRoom.Col > cavern.OuterWalls.Col.Min)
            player.CurrentRoom = new Room(player.CurrentRoom.Row, player.CurrentRoom.Col - 1);
        else
            Display.Error("There's a wall over there, press a key to continue...");
    }
}

public class EastCommand : IPlayerCommand
{
    public void Execute(Player player, Cavern cavern)
    {
        if (player.CurrentRoom.Col < cavern.OuterWalls.Col.Max)
            player.CurrentRoom = new Room(player.CurrentRoom.Row, player.CurrentRoom.Col + 1);
        else
            Display.Error("There's a wall over there, press a key to continue...");
    }
}

public class ShootNorthCommand : IPlayerCommand
{
    public void Execute(Player player, Cavern cavern)
    {
        if (player.Arrows > 0)
        {
            player.Arrows--;

            for (int i = 0; i < cavern.Amaroks.Count; i++)
            {
                if (player.CurrentRoom.Row == cavern.Amaroks[i].Row - 1 && player.CurrentRoom.Col == cavern.Amaroks[i].Col)
                {
                    cavern.Amaroks.RemoveAt(i);
                    Display.KilledEnemy("You killed an Amarok!");

                    return;
                }
            }
            for (int i = 0; i < cavern.Maelstroms.Count; i++)
            {
                if (player.CurrentRoom.Row == cavern.Maelstroms[i].Row - 1 && player.CurrentRoom.Col == cavern.Maelstroms[i].Col)
                {
                    cavern.Maelstroms.RemoveAt(i);
                    Display.KilledEnemy("You killed a Maelstrom!");

                    return;
                }
            }
        }
    }
}

public class ShootSouthCommand : IPlayerCommand
{
    public void Execute(Player player, Cavern cavern)
    {
        if (player.Arrows > 0)
        {
            player.Arrows--;

            for (int i = 0; i < cavern.Amaroks.Count; i++)
            {
                if (player.CurrentRoom.Row == cavern.Amaroks[i].Row + 1 && player.CurrentRoom.Col == cavern.Amaroks[i].Col)
                {
                    cavern.Amaroks.RemoveAt(i);
                    Display.KilledEnemy("You killed an Amarok!");

                    return;
                }
            }
            for (int i = 0; i < cavern.Maelstroms.Count; i++)
            {
                if (player.CurrentRoom.Row == cavern.Maelstroms[i].Row + 1 && player.CurrentRoom.Col == cavern.Maelstroms[i].Col)
                {
                    cavern.Maelstroms.RemoveAt(i);
                    Display.KilledEnemy("You killed a Maelstrom!");

                    return;
                }
            }
        }
    }
}

public class ShootEastCommand : IPlayerCommand
{
    public void Execute(Player player, Cavern cavern)
    {
        if (player.Arrows > 0)
        {
            player.Arrows--;

            for (int i = 0; i < cavern.Amaroks.Count; i++)
            {
                if (player.CurrentRoom.Col== cavern.Amaroks[i].Col - 1 && player.CurrentRoom.Row == cavern.Amaroks[i].Row)
                {
                    cavern.Amaroks.RemoveAt(i);
                    Display.KilledEnemy("You killed an Amarok!");

                    return;
                }
            }

            for (int i = 0; i < cavern.Maelstroms.Count; i++)
            {
                if (player.CurrentRoom.Col == cavern.Maelstroms[i].Col - 1 && player.CurrentRoom.Row == cavern.Maelstroms[i].Row)
                {
                    cavern.Maelstroms.RemoveAt(i);
                    Display.KilledEnemy("You killed a Maelstrom!");

                    return;
                }
            }
        }
    }
}

public class ShootWestCommand : IPlayerCommand
{
    public void Execute(Player player, Cavern cavern)
    {
        if (player.Arrows > 0)
        {
            player.Arrows--;

            for (int i = 0; i < cavern.Amaroks.Count; i++)
            {
                if (player.CurrentRoom.Col == cavern.Amaroks[i].Col + 1 && player.CurrentRoom.Row == cavern.Amaroks[i].Row)
                {
                    cavern.Amaroks.RemoveAt(i);
                    Display.KilledEnemy("You killed an Amarok!");

                    return;
                }
            }

            for (int i = 0; i < cavern.Maelstroms.Count; i++)
            {
                if (player.CurrentRoom.Col == cavern.Maelstroms[i].Col + 1 && player.CurrentRoom.Row == cavern.Maelstroms[i].Row)
                {
                    cavern.Maelstroms.RemoveAt(i);
                    Display.KilledEnemy("You killed a Maelstrom!");

                    return;
                }
            }
        }
    }
}

public class FountainCommand : IPlayerCommand
{
    public void Execute(Player player, Cavern cavern)
    {
        if (player.CurrentRoom == cavern.Fountain && !player.HasEnabledFountain)
        {
            player.HasEnabledFountain = true;
            return;
        }
        if (player.CurrentRoom == cavern.Fountain && player.HasEnabledFountain)
        {
            Display.Error("The fountain is already activated, press a key to continue...");
            return;
        }

        Display.Error("The fountain is not in this room, press a key to continue...");
    }
}

public class HelpCommand : IPlayerCommand
{
    public void Execute(Player player, Cavern cavern)
    {
        Display.Help();
    }
}