namespace Challenges.Part_2.Level_24.Tic_Tac_Toe;

public class TicTacToeBoardRenderer(TicTacToeBoard board)
{
    private readonly TicTacToeBoard _board = board;

    public void Render()
    {
        int index = 0;

        for (int y = 0; y < _board.Yaxis; y++)
        {
            for (int x = 0; x < _board.Xaxis; x++)
            {
                dynamic symbol = _board.Tiles[index].Symbol != null ? _board.Tiles[index].Symbol : index;

                Console.Write(symbol is int tileIndex ? tileIndex + 1 : symbol);
                index++;
            }

            Console.WriteLine();
        }
    }
}
