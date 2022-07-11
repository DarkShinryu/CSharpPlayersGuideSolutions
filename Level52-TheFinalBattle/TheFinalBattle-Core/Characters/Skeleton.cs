public class Skeleton : Character
{
    public Skeleton(string name, ConsoleColor color, int maxHitPoints) : base(name, color, maxHitPoints) => Action = new BoneCrunchAction();
}