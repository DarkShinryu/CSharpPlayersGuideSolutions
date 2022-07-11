string? word;

while (true)
{
    do
    {
        Console.Write("Enter a word: ");
        word = Console.ReadLine();
    } while (string.IsNullOrWhiteSpace(word));

    ComputeOutput(word);
}


async Task ComputeOutput(string word)
{
    DateTime startTime = DateTime.Now;
    ulong attemptsCount = await RandomlyRecreateAsync(word);
    TimeSpan executionTime = DateTime.Now - startTime;

    Console.WriteLine($"The word '{word}' took {attemptsCount} attempts for a total time of " +
    $"{executionTime.Hours:00}:{executionTime.Minutes:00}:{executionTime.Seconds:00}.{executionTime.Milliseconds:000}");
}

ulong RandomlyRecreate(string word)   // I changed the type to ulong in case the word is not short
{
    Random random = new Random();
    string newWord;
    ulong attemptsCount = 0;

    do
    {
        newWord = string.Empty;

        for (int i = 0; i < word.Length; i++)
            newWord += (char)('a' + random.Next(26));

        attemptsCount++;
    } while (newWord != word);

    return attemptsCount;
}

Task<ulong> RandomlyRecreateAsync(string word) => Task.Run(() => RandomlyRecreate(word));