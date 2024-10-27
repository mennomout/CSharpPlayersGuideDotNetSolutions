using Helpers;

namespace Challenges.Part_2.Level_24.Rock_Paper_Scissors;

public class RockPaperScissorsChallange() : Challenge("Rock Paper Scissors")
{
    public override void Run(object[]? parameters = null)
    {
        Console.WriteLine("Welcome to Rock-Paper-Scissors!");
        Console.WriteLine("This is a game for two players. Please enter your names.");

        int rounds = 2;

        while (rounds % 2 == 0)
        {
            rounds = InputHelper.GetInputOrDefault<int>("Enter an uneven number of rounds you want to play");
        }

        RPSPlayer playerOne = new()
        {
            Name = InputHelper.GetInputOrDefault<string>("Player one enter your name")
        };

        RPSPlayer playerTwo = new()
        {
            Name = InputHelper.GetInputOrDefault<string>("Player two enter your name")
        };

        RPSGameManager gameManager = new(playerOne, playerTwo, rounds);
        gameManager.Run();  
    }
}
