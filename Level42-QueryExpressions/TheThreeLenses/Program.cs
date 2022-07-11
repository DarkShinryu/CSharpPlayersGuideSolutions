int[] numbers = new int[] { 1, 9, 2, 8, 3, 7, 4, 6, 5 };

IEnumerable<int> proceduralFilter = GetProceduralFilter(numbers);
IEnumerable<int> keywordQueryFilter = GetKeywordQueryFilter(numbers);
IEnumerable<int> methodQueryFilter = GetMethodQueryFilter(numbers);

List<IEnumerable<int>> filters = new List<IEnumerable<int>>() { proceduralFilter, keywordQueryFilter, methodQueryFilter };
foreach (IEnumerable<int> filter in filters)
{
    Console.Write("Numbers:");
    foreach (int number in filter)
        Console.Write(" " + number);

    Console.WriteLine();
}



IEnumerable<int> GetProceduralFilter(int[] numbers)
{
    List<int> result = new List<int>();

    for (int i = 0; i < numbers.Length; i++)
        if (numbers[i] % 2 == 0)
            result.Add(numbers[i] * 2);     // Note: I'm also doubling the values here

    result.Sort();

    return result;
}

IEnumerable<int> GetKeywordQueryFilter(int[] numbers)
{
    return from n in numbers
           where n % 2 == 0
           orderby n
           select n * 2;
}

IEnumerable<int> GetMethodQueryFilter(int[] numbers)
{
    return numbers
                .Where(n => n % 2 == 0)
                .OrderBy(n => n)
                .Select(n => n * 2);

}

// In this case the keyword query is my favorite, it's looks to be a bit more streamlined.
// If I needed the additional functionality of the method syntax than I would pick that one
// While not bad, the procedutal one is quite a bit messier and harder to understand than the query expressions.