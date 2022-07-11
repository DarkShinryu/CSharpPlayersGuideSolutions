namespace TicTacToe
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.Title = "Tic-Tac-Toe";

            Game game = new Game();
            game.Run();
        }
    }
}