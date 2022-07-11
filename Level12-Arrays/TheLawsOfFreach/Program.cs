int[] array = new int[] { 4, 51, -7, 13, -99, 15, -8, 45, 90 };
int currentSmallest = int.MaxValue; // Start higher than anything in the array.
int total = 0;

foreach (int number in array)   // One loop is enough to do both
{
    if (number < currentSmallest)
        currentSmallest = number;

    total += number;
}
float average = (float)total / array.Length;

Console.WriteLine($"Smallest: {currentSmallest}");
Console.WriteLine($"Average: {average:#.##}");