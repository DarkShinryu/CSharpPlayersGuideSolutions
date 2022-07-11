public class Boss : Character
{
    public Boss(string name, ConsoleColor color, int maxHitPoints) : base(name, color, maxHitPoints) => Action = new UnravelingAction();
}