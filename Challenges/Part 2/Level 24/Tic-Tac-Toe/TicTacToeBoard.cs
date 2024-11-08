namespace Challenges.Part_2.Level_24.Tic_Tac_Toe;

public class TicTacToeBoard
{
    public int Xaxis { get; set; }
    public int Yaxis { get; set; }
    public List<TicTacToeBoardTile> Tiles { get; set; } = [];

    public TicTacToeBoard(int xAxis = 3, int yAxis = 3)
    {
        Xaxis = xAxis;
        Yaxis = yAxis;
        Tiles = new(xAxis * yAxis);

        for (int i = 0; i < Tiles.Capacity; i++)
        {
            Tiles.Add(new(i));
        }
    }

    public bool IsFull => !Tiles.Any(x => x.Symbol is null);

    // This code should be more efficient and doens't take into account diagonals.
    // For now this will have to do.
    public bool TryGetWinner(out TicTacToeSymbol? winner)
    {
        winner = null;

        // Check columns for a winner
        for (int i = 0; i <= 3; i++)
        {
            if (Tiles[i].Symbol != null && Tiles[i].Symbol == Tiles[i + 3].Symbol && Tiles[i].Symbol == Tiles[i + 6].Symbol)
            {
                winner = Tiles[i].Symbol;

                return true;
            }
        }

        // Check rows for a winner.
        for (int i = 0; i <= 6; i += 3)
        {
            if (Tiles[i].Symbol != null && Tiles[i].Symbol == Tiles[i + 1].Symbol && Tiles[i].Symbol == Tiles[i + 2].Symbol)
            {
                winner = Tiles[i].Symbol;

                return true;
            }
        }

        return false;
    }

}
