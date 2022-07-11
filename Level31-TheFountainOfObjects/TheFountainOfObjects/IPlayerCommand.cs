public interface IPlayerCommand
{
    public void Move(Player player, Cavern cavern); // I need the cavern for the walls and fountain room positions
}

public class NorthCommand : IPlayerCommand
{
    public void Move(Player player, Cavern cavern)
    {
        if (player.CurrentPos.Row > cavern.OuterWallsRow.Min)
            player.CurrentPos = new Coordinate(player.CurrentPos.Row - 1, player.CurrentPos.Col);
        else
            Display.Error("There's a wall over there, press a key to continue...");
    }
}

public class SouthCommand : IPlayerCommand
{
    public void Move(Player player, Cavern cavern)
    {
        if (player.CurrentPos.Row < cavern.OuterWallsRow.Max)
            player.CurrentPos = new Coordinate(player.CurrentPos.Row + 1, player.CurrentPos.Col);
        else
            Display.Error("There's a wall over there, press a key to continue...");
    }
}

public class WestCommand : IPlayerCommand
{
    public void Move(Player player, Cavern cavern)
    {
        if (player.CurrentPos.Col > cavern.OuterWallsCol.Min)
            player.CurrentPos = new Coordinate(player.CurrentPos.Row, player.CurrentPos.Col - 1);
        else
            Display.Error("There's a wall over there, press a key to continue...");
    }
}

public class EastCommand : IPlayerCommand
{
    public void Move(Player player, Cavern cavern)
    {
        if (player.CurrentPos.Col < cavern.OuterWallsCol.Max)
            player.CurrentPos = new Coordinate(player.CurrentPos.Row, player.CurrentPos.Col + 1);
        else
            Display.Error("There's a wall over there, press a key to continue...");
    }
}

public class FountainCommand : IPlayerCommand
{
    public void Move(Player player, Cavern cavern)
    {
        if (player.CurrentPos == cavern.FountainPos && !player.HasEnabledFountain)
        {
            player.HasEnabledFountain = true;
            return;
        }
        if (player.CurrentPos == cavern.FountainPos && player.HasEnabledFountain)
        {
            Display.Error("The fountain is already activated, press a key to continue...");
            return;
        }

        Display.Error("The fountain is not in this room, press a key to continue...");
    }
}