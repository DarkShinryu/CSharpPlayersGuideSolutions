public class Party
{
    public string Name { get; }
    public List<Character> Characters { get; private set; }
    public bool Defeated => Characters.Count <= 0 ? true : false;

    public Party(string name)
    {
        Name = name;
        Characters = new List<Character>();
    }

    public void EmptyParty() => Characters.Clear();

    public void RemoveDeadCharacters()
    {
        List<Character> newCharacters = new List<Character>();

        foreach (Character character in Characters)
        {
            if (character.IsDead)
                continue;

            newCharacters.Add(character);
        }

        Characters = newCharacters;
    }
}