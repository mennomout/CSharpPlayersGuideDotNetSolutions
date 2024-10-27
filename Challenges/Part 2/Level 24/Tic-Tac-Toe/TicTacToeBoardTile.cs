namespace Challenges.Part_2.Level_24.Tic_Tac_Toe;

public class TicTacToeBoardTile(int id)
{
    public TicTacToeSymbol? Symbol { get; set; } = null;
    public int Id { get; init; } = id;
}
