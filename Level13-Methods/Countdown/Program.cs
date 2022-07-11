Countdown(10, 1);

void Countdown(int max, int min)
{
    if (max < min) // This is our base case to ensure we eventually come out of recursion
        return;

    Console.WriteLine(max);
    Countdown(--max, min);  // Clever use of the prefix decrement operator
}