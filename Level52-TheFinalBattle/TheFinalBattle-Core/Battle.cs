public class Battle
{

    private DateTime _startTime;

    public Party Heroes { get; }
    public Party Villains { get; }
    public int TurnCount { get; private set; }
    public TimeSpan Duration { get; private set; }

    public Battle(Party heroes, Party villains)
    {
        Heroes = heroes;
        Villains = villains;
        TurnCount = 1;
    }

    public void Start(int battleNumber)
    {
        SetPartyTarget(Heroes, Villains);
        SetPartyTarget(Villains, Heroes);

        _startTime = DateTime.Now;

        while (!Heroes.Defeated && !Villains.Defeated)
        {
            Display.TurnInfo(this);
            Turn(Heroes, Villains);
            Turn(Villains, Heroes);

            EndTurn();
        }

        Duration = DateTime.Now - _startTime;
        Display.BattleResult(this);
    }

    private void SetPartyTarget(Party party, Party targetParty)
    {
        foreach (Character character in party.Characters)
            character.TargetParty = targetParty;
    }

    private void Turn(Party party, Party targetParty)
    {
        foreach (Character character in party.Characters)
        {
            if (!targetParty.Defeated)
            {
                Display.TurnIntro(character);
                character.TakeTurn();
                Display.TurnExecution(character, character.Action.Target);

                targetParty.RemoveDeadCharacters();

                Thread.Sleep(1000);
                Console.WriteLine();
            }
        }
    }

    private void EndTurn()
    {
        TurnCount++;

        Console.Write("Press a key to end the turn...");
        Console.ReadKey(true);
        Console.Clear();
    }
}