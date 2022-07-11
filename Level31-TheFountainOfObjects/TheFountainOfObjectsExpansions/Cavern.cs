public class Cavern
{
    public Room Entrance { get; }
    public Room Fountain { get; }
    public List<Room> Pits { get; }
    public List<Room> Maelstroms { get; }
    public List<Room> Amaroks { get; }
    public OuterWalls OuterWalls { get; }

    public Cavern(CavernSize size)
    {
        Entrance = new Room(0, 0);  // 0,0 in all cases, but we can easily change that if we want to

        if (size == CavernSize.Small)
        {
            OuterWalls = new OuterWalls(new Extents(0, 3), new Extents(0, 3));
            Fountain = new Room(0, 2);
            Pits = new List<Room> { new Room(1, 2) };
            Maelstroms = new List<Room> { new Room(3, 1) };
            Amaroks = new List<Room> { new Room(2, 1) };

            return;
        }
        if (size == CavernSize.Medium)
        {
            OuterWalls = new OuterWalls(new Extents(0, 5), new Extents(0, 5));
            Fountain = new Room(5, 3);
            Pits = new List<Room> { new Room(3, 4), new Room(0, 5), };
            Maelstroms = new List<Room> { new Room(3, 1) };
            Amaroks = new List<Room> { new Room(2, 1), new Room(3, 5) };

            return;
        }

        // Large (not in a if statement to avoid null warnings)
        OuterWalls = new OuterWalls(new Extents(0, 7), new Extents(0, 7));
        Fountain = new Room(6, 7);
        Pits = new List<Room> { new Room(3, 4), new Room(0, 5), new Room(2, 2), new Room(7, 6) };
        Maelstroms = new List<Room> { new Room(3, 1), new Room(6, 6) };
        Amaroks = new List<Room> { new Room(2, 1), new Room(5, 5), new Room(0, 7) };

    }

    public void UpdateMealstromPosition(Room playerPosition)
    {
        for (int i = 0; i < Maelstroms.Count; i++)
        {
            if (Maelstroms[i] == playerPosition)
            {
                int updatedMaelstromRow = Math.Clamp(Maelstroms[i].Row - 1, (int)OuterWalls.Row.Min, (int)OuterWalls.Row.Max);
                int updatedMaelstromCol = Math.Clamp(Maelstroms[i].Col + 2, (int)OuterWalls.Col.Min, (int)OuterWalls.Col.Max);
                Maelstroms[i] = new Room(updatedMaelstromRow, updatedMaelstromCol);
            }
        }
    }
}

// These are closely related to Cavern, so I'll put them in the same file
public static class CavernGenerator
{
    public static Cavern Run() => new Cavern(GetCavernSize());

    private static CavernSize GetCavernSize()
    {
        CavernSize size;
        do
        {
            Display.PlayerPrompt("Enter the size of the cavern (small, medium, large): ");
            size = (Console.ReadLine() ?? "Error").ToLower() switch
            {
                "s"      => CavernSize.Small,
                "small"  => CavernSize.Small,
                "m"      => CavernSize.Medium,
                "medium" => CavernSize.Medium,
                "l"      => CavernSize.Large,
                "large"  => CavernSize.Large,
                _        => CavernSize.Empty
            };
        } while (size == CavernSize.Empty);

        return size;
    }
}

public enum CavernSize { Empty, Small, Medium, Large }   