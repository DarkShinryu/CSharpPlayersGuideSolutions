Random random = new Random();
int totalCookies = 10;
int oatmealCookieIndex = random.Next(totalCookies);

Game game = new Game(totalCookies, oatmealCookieIndex);
game.Run();


public class Game
{
    private Player _player1;
    private Player _player2;
    private List<Cookie> cookies;

    public Game(int totalCookies, int oatmealCookieIndex)
    {
        _player1 = new Player("Player 1");
        _player2 = new Player("Player 2");
        cookies = new List<Cookie>(totalCookies);
        PopulateCookiesList(oatmealCookieIndex);
    }

    public void Run()
    {
        try
        {
            throw new NotSupportedException();

        }
        catch (NotSupportedException e)
        {
            Console.WriteLine(e.Message);
        }
        Player[] players = new Player[2] { _player1, _player2 };

        while (cookies.Contains(Cookie.OatmealRaisin))
        {
            foreach (Player player in players)
            {
                int index = GetNumber(player);

                try
                {
                    if (cookies[index] == Cookie.OatmealRaisin)
                        throw new Exception($"{player.Name} eated the outmeal raisin cookie, it's disgusting!");

                    Console.WriteLine($"{player.Name} eated a chocolate chip cookie, it's delicious!\n");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    break;
                }
                finally
                {
                    cookies[index] = Cookie.Eated;
                }
            }
        }
    }

    private int GetNumber(Player player)
    {
        int index = int.MinValue;

        // The third check only happens if the first two return false, thus preventing an out of range exception (logic > exception throwing)
        while (index < 0 || index >= cookies.Count || cookies[index] == Cookie.Eated)
        {
            do
            {
                Console.Write($"{player.Name}, enter a number from 0 to 9: ");
            } while (!int.TryParse(Console.ReadLine(), out index));
        }

        return index;
    }

    private void PopulateCookiesList(int oatmealCookieIndex)
    {
        for (int i = 0; i < cookies.Capacity; i++)
        {
            if (i == oatmealCookieIndex)
            {
                cookies.Add(Cookie.OatmealRaisin);
                continue;
            }

            cookies.Add(Cookie.ChocolateChip);
        }
    }
}

public record Player(string Name);

public enum Cookie { Eated, ChocolateChip, OatmealRaisin }