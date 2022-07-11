public class Hero : Character
{
    private Random _random = new Random();

    public ControlMode ControlMode { get; }

    public Hero(string name, ConsoleColor color, int maxHitPoints, ControlMode controlMode) : base(name, color, maxHitPoints) => ControlMode = controlMode;

    public override void TakeTurn()
    {
        Action.Target = null;

        SetAction();
        SetActionTarget();

        if (Action.Target != null)
            Action.Target.Health.Current -= Action.Damage;
    }

    private void SetAction()
    {
        if (ControlMode == ControlMode.Automated)
        {
            Action = _random.Next(1, 11) % 10 == 0 ? new NothingAction() : new PunchAction(); // 1/10 chance of doing nothing seems reasonable
            return;
        }

        GetManualAction();
    }

    private void GetManualAction()
    {
        string? userAction;
        do
        {
            Console.Write("Enter an action (1 - Nothing | 2 - Punch): ");
            userAction = Console.ReadLine()?.ToLower();
            Action = userAction switch
            {
                "1" or "nothing" => new NothingAction(),
                "2" or "punch"   => new PunchAction(),
                _                => new NothingAction()
            };
        } while (string.IsNullOrWhiteSpace(userAction) || (userAction != "1" && userAction != "nothing" && userAction != "2" && userAction != "punch"));
    }

    protected override void SetActionTarget()
    {
        Action.Target = null;

        if (TargetParty != null && !TargetParty.Defeated && Action is not NothingAction)
        {
            base.SetActionTarget();

            if (Action.Target == null)  // If we're here and target is still null, we're dealing with multiple targets
                HandleMultipleTargets();
        }
    }

    private void HandleMultipleTargets()
    {
        if (ControlMode == ControlMode.Automated)
        {
            if (TargetParty != null && TargetParty.Characters.Count > 0)
                Action.Target = TargetParty.Characters[0];

            return;
        }

        int targetIndex;
        do
        {
            Console.Write($"Select a target (");
            for (int i = 0; i < TargetParty?.Characters.Count; i++)
            {
                if (!TargetParty.Characters[i].IsDead)
                {
                    if (i + 1 == TargetParty.Characters.Count)  // Last enemy, needs different formatting
                    {
                        Console.Write($"{i + 1} - {TargetParty.Characters[i]}): ");
                        continue;
                    }

                    Console.Write($"{i + 1} - {TargetParty.Characters[i]} | ");
                }
            }

        } while (!int.TryParse(Console.ReadLine(), out targetIndex) || targetIndex <= 0 || targetIndex > TargetParty?.Characters.Count);

        Action.Target = TargetParty?.Characters[targetIndex - 1];
    }
}

public enum ControlMode { Manual, Automated }