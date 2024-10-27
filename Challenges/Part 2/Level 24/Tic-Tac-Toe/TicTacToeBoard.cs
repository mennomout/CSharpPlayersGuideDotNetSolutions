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

        if (Tiles[0].Symbol != null && Tiles[0].Symbol == Tiles[3].Symbol && Tiles[0].Symbol == Tiles[6].Symbol)
        {
            winner = Tiles[0].Symbol;

            return true;
        }
        else if (Tiles[1].Symbol != null && Tiles[1].Symbol == Tiles[4].Symbol && Tiles[0].Symbol == Tiles[7].Symbol)
        {
            winner = Tiles[1].Symbol;

            return true;
        }
        else if (Tiles[2].Symbol != null && Tiles[2].Symbol == Tiles[5].Symbol && Tiles[0].Symbol == Tiles[8].Symbol)
        {
            winner = Tiles[2].Symbol;

            return true;
        }
        else if (Tiles[0].Symbol != null && Tiles[0].Symbol == Tiles[1].Symbol && Tiles[0].Symbol == Tiles[2].Symbol)
        {
            winner = Tiles[0].Symbol;

            return true;
        }
        else if (Tiles[3].Symbol != null && Tiles[3].Symbol == Tiles[4].Symbol && Tiles[3].Symbol == Tiles[5].Symbol)
        {
            winner = Tiles[3].Symbol;

            return true;
        }
        else if (Tiles[6].Symbol != null && Tiles[6].Symbol == Tiles[7].Symbol && Tiles[6].Symbol == Tiles[8].Symbol)
        {
            winner = Tiles[2].Symbol;

            return true;
        }

        return false;
    }

}
