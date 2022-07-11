(SoupType SoupType, Ingredient Ingredient, Seasoning Seasoning) soup = GetSoup();
DisplaySoup(soup);




// Methods and Enumerations

void DisplaySoup((SoupType SoupType, Ingredient Ingredient, Seasoning Seasoning) soup)
{
    Console.WriteLine($"{soup.Seasoning} {soup.Ingredient} {soup.SoupType}");
}

(SoupType SoupType, Ingredient Ingredient, Seasoning Seasoning) GetSoup()
{
    SoupType soupType = GetSoupType();
    Ingredient ingredient = GetIngredient();
    Seasoning seasoning = GetSeasoning();

    return (soupType, ingredient, seasoning);
}

SoupType GetSoupType()
{
    SoupType soupType = SoupType.Unknown;
    string soupAsString = string.Empty;

    while(soupType == SoupType.Unknown)
    {
        Console.Write("Enter the type of soup (soup, stew, gumbo): ");
        soupAsString = Console.ReadLine().ToLower();

        soupType = soupAsString switch
        {
            "soup"  => SoupType.Soup,
            "stew"  => SoupType.Stew,
            "gumbo" => SoupType.Gumbo,
            _       => SoupType.Unknown
        };
    }

    return soupType;
}

Ingredient GetIngredient()
{
    Ingredient ingredient = Ingredient.Unknown;
    string ingredientAsString = string.Empty;

    while (ingredient == Ingredient.Unknown)
    {
        Console.Write("Enter the ingredient (mushrooms, chicken, carrots, potatoes): ");
        ingredientAsString = Console.ReadLine().ToLower();

        ingredient = ingredientAsString switch
        {
            "mushrooms" => Ingredient.Mushrooms,
            "chicken"   => Ingredient.Chicken,
            "carrots"   => Ingredient.Carrots,
            "potatoes"  => Ingredient.Potatoes,
            _           => Ingredient.Unknown
        };
    }

    return ingredient;
}

Seasoning GetSeasoning()
{
    Seasoning seasoning = Seasoning.Unknown;
    string seasoningAsString = string.Empty;

    while (seasoning == Seasoning.Unknown)
    {
        Console.Write("Enter the seasoning (spicy, salty, sweet): ");
        seasoningAsString = Console.ReadLine().ToLower();

        seasoning = seasoningAsString switch
        {
            "spicy" => Seasoning.Spicy,
            "salty" => Seasoning.Salty,
            "sweet" => Seasoning.Sweet,
            _       => Seasoning.Unknown
        };
    }

    return seasoning;
}

enum SoupType { Unknown, Soup, Stew, Gumbo }
enum Ingredient { Unknown, Mushrooms, Chicken, Carrots, Potatoes }
enum Seasoning { Unknown, Spicy, Salty, Sweet }