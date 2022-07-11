Console.Write("Enter a number: ");
int userNumber = int.Parse(Console.ReadLine());

if (userNumber % 2 == 0)
    Console.WriteLine($"Tick");
else
    Console.WriteLine($"Tock");

// Alternate solution with conditional operator
// Console.WriteLine(userNumber % 2 == 0 ? "Tick" : "Tock");