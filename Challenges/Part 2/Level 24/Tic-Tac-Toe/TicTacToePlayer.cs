namespace Challenges.Part_2.Level_24.Tic_Tac_Toe;

public class TicTacToePlayer
{
    public TicTacToePlayer(string name, TicTacToeSymbol symbol)
    {
        Name = name;
        Symbol = symbol;
    }

    public string Name { get; set; }
    public TicTacToeSymbol Symbol { get; set; }
}
