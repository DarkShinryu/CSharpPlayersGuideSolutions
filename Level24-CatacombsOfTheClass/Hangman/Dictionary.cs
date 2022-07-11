public class Dictionary
{
    public string[] Words { get; }

    public Dictionary() => Words = File.ReadAllLines(@"..\..\..\Words.txt");
}