public class Game
{
    private bool isGameOver;
    public Player Player { get; }

    public Board Board { get; private set; }

    public Game(int n)
    {
        Board = new Board(n);
        Player = new Player(Board);
        isGameOver = false;

        Board.PopulateBoard();
    }

    public void Run()
    {

        while (!isGameOver)
        {
            Display.Board(this);
            Player.MovesCount++;
            Player.MoveTile(Board.GetTileValue());
            if (Board.IsOrdered()) isGameOver = true;
        }

        Display.Board(this);
        Display.End(this);
    }
}