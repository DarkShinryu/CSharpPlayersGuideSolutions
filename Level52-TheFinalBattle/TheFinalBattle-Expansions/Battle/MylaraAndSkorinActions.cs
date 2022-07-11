public class CannonAction : PunchAction
{
    private Random _random = new Random();

    public CannonAction(int turn)
    {
        Name = "Cannon";
        if (turn % 3 == 0 && turn % 5 == 0) Damage = 300;
        else if (turn % 3 == 0) Damage = 150;
        else if (turn % 5 == 0) Damage = 150;
        else Damage = 100;
    }

    public override void SetSuccess() => Success = _random.NextDouble() >= 0.5; // The cannon is very powerful but misses a lot!
}