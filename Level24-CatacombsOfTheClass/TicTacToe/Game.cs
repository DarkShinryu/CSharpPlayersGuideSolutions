public class Game
{
    public Player Player1 { get; }
    public Player Player2 { get; }
    public Sign[,] Board { get; }
    public bool IsGameOver { get; private set; }
    public bool IsDraw { get; private set; }

    public Game()
    {
        Player1 = new Player("Player 1", Sign.X);
        Player2 = new Player("Player 2", Sign.O);
        Board = new Sign[3,3];
        InitializeBoard();
        IsGameOver = false;
        IsDraw = false;
    }

    public void Run()
    {
        Player[] players = new Player[] { Player1, Player2 };

        while (!IsGameOver)
        {
            foreach (Player player in players)
            {
                Display.MainScreen(player, Board);
                player.SetSelectedSquare();
                UpdateBoard(player);
                CheckBoard(player);
                IsGameOver = CheckGameOver(player);

                if (IsGameOver) break;
            }
        }

        Display.EndScreen(Board, players, this);
    }

    private void InitializeBoard()
    {
        for (int row = 0; row < Board.GetLength(0); row++)
        {
            for (int col = 0; col < Board.GetLength(1); col++)
            {
                Board[row, col] = Sign.Empty;
            }
        }
    }

    private void UpdateBoard(Player player)
    {
        int row = player.SelectedSquare / Board.GetLength(0);   // This is inverted
        if      (row == 0) row = 2;
        else if (row == 2) row = 0;
        int col = player.SelectedSquare % Board.GetLength(1);

        if (Board[row, col] == Sign.Empty)
            Board[row, col] = player.Sign;
    }

    private void CheckBoard(Player player)
    {
        if (Board[0,0] == player.Sign)
        {
            if (Board[0, 1] == player.Sign && Board[0, 2] == player.Sign) player.IsWinner = true;
            if (Board[1, 0] == player.Sign && Board[2, 0] == player.Sign) player.IsWinner = true;
        }
        if (Board[2, 2] == player.Sign)
        {
            if (Board[0, 2] == player.Sign && Board[1, 2] == player.Sign) player.IsWinner = true;
            if (Board[2, 0] == player.Sign && Board[2, 1] == player.Sign) player.IsWinner = true;
        }
        if (Board[1, 1] == player.Sign)
        {
            if (Board[2, 0] == player.Sign && Board[0, 2] == player.Sign) player.IsWinner = true;
            if (Board[0, 0] == player.Sign && Board[2, 2] == player.Sign) player.IsWinner = true;
            if (Board[1, 0] == player.Sign && Board[1, 2] == player.Sign) player.IsWinner = true;
            if (Board[0, 1] == player.Sign && Board[2, 1] == player.Sign) player.IsWinner = true;
        }
    }

    private bool CheckGameOver(Player player)
    {
        bool boardIsFull = true;

        for (int row = 0; row < Board.GetLength(0); row++)
        {
            for (int col = 0; col < Board.GetLength(1); col++)
            {
                if (Board[row, col] == Sign.Empty)
                {
                    boardIsFull = false;
                    break;
                }
            }

            if (!boardIsFull) break;     // Better than using a goto I guess
        }

        if (player.IsWinner)    // One of the player is the winner
        {
            return true;
        }
        else if (!player.IsWinner && boardIsFull)   // It's a draw
        {
            IsDraw = true;
            return true;
        }

        return false;
    }
}