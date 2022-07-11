PasswordValidator validator = new PasswordValidator();

while (true)
{
    Console.Write("Enter a password: ");
    string password = Console.ReadLine() ?? string.Empty;   // Taking care of null by providing an empty string

    if (validator.IsValidPassword(password))
        Console.WriteLine("This is a valid password.");
    else
        Console.WriteLine("This is not a valid password.");
}

public class PasswordValidator
{
    public bool IsValidPassword(string password)
    {
        if (HasAllowedLength(password) && HasRequiredCharacters(password) && !HasBadCharacters(password))
            return true;
        
        return false;
    }

    private bool HasAllowedLength(string password)
    {
        if (password.Length >= 6 && password.Length <= 13) return true;
        return false;
    }

    private bool HasRequiredCharacters(string password)
    {
        bool HasUpper = false;
        bool HasLower = false;
        bool HasNumber = false;

        foreach (char character in password)
        {
            if  (char.IsUpper(character)) HasUpper = true;
            else if (char.IsLower(character)) HasLower = true;
            else if (char.IsNumber(character)) HasNumber = true;
        }

        if (HasUpper && HasLower && HasNumber) return true;
        return false;
    }

    private bool HasBadCharacters(string password)
    {
        foreach (char character in password)
            if (character == 'T' || character == '&') return true;

        return false;
    }
}