namespace Challenges.Part_2.Level_24.Tic_Tac_Toe;

public class TicTacToeChallenge() : Challenge("Tic-Tac-Toe")
{
    public override void Run(object[]? parameters = null)
    {
        TicTacToeConfiguration configuration = new()
        {
            XaxisLenght = 3,
            YaxisLenght = 3,
            Players = [new TicTacToePlayer("Player 1", TicTacToeSymbol.O), new TicTacToePlayer("Player 2", TicTacToeSymbol.X) ]
        };

        TicTacToe ticTacToeGame = new(configuration);

        ticTacToeGame.Play();
    }
}
