int[] userNumbers = new int[5];

for (int i = 0; i < userNumbers.Length; i++)
{
    Console.Write($"Enter number {i + 1} of {userNumbers.Length}: ");
    userNumbers[i] = Convert.ToInt32(Console.ReadLine());
}

int[] copy = new int[userNumbers.Length];
for (int i = 0; i < copy.Length; i++)
{
    copy[i] = userNumbers[i];
}

Console.Clear();


Console.WriteLine("Original array");
foreach (int number in userNumbers)
{
    Console.WriteLine(number);
}

Console.WriteLine();
Console.WriteLine("Copy array");
foreach (int number in copy)
{
    Console.WriteLine(number);
}