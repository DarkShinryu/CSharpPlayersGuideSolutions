RecentNumbers recentNumbers = new RecentNumbers();

Thread thread = new Thread(GenerateNumbers);
thread.Start(recentNumbers);

while (true)
{
    Console.ReadKey(true);

    lock (recentNumbers)
    {
        if (recentNumbers.Previous == recentNumbers.Last)
            Console.WriteLine("The stream has generated two equal numbers.");
        else
            Console.WriteLine("The stream has generated two different numbers.");
    }
}


void GenerateNumbers(object? obj)
{
    if (obj == null || obj.GetType() != typeof(RecentNumbers)) return;

    RecentNumbers recentNumbers = (RecentNumbers)obj;
    Random random = new Random();

    while (true)
    {
        lock (recentNumbers)
        {
            recentNumbers.Previous = recentNumbers.Last;
            recentNumbers.Last = random.Next(10);
            Console.WriteLine(recentNumbers.Last);
        }

        Thread.Sleep(1000);
    }
}

public class RecentNumbers
{
    public int Previous { get; set; }
    public int Last { get; set; } = -1;
}