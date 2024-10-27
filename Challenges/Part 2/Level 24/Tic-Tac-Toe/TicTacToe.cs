using Helpers;

namespace Challenges.Part_2.Level_24.Tic_Tac_Toe;

public class TicTacToe
{
    private readonly TicTacToeBoard _board;
    private readonly TicTacToeBoardRenderer _renderer;
    private readonly List<TicTacToePlayer> _players;

    public TicTacToe(TicTacToeConfiguration configuration)
    {
        _board = new(configuration.XaxisLenght, configuration.YaxisLenght);
        _renderer = new(_board);
        _players = configuration.Players;
    }

    public void Play()
    {
        TicTacToeSymbol? winner = null;

        while (!_board.IsFull && !_board.TryGetWinner(out winner))
        {
            foreach (var player in _players)
            {
                _renderer.Render();

                if (_board.IsFull || _board.TryGetWinner(out _))
                {
                    break;
                }

                Console.WriteLine($"It's {player.Name}'s turn (symbol = {player.Symbol}).");
                var index = InputHelper.GetNumberInRange("Enter the number of a square without symbol", 1, 9) - 1;

                if (_board.Tiles[index].Symbol is null)
                {
                    _board.Tiles[index].Symbol = player.Symbol;
                }

                Console.Clear();
            }
        }

        if (winner != null)
        {
            Console.WriteLine($"Congratulations {_players.FirstOrDefault(x => x.Symbol == winner)?.Name}!");
        }
    }
}
