using Helpers;

namespace Challenges.Part_2.Level_24.Rock_Paper_Scissors;

public class RPSGameManager
{
    public RPSGameManager(RPSPlayer playerOne, RPSPlayer playerTwo, int rounds)
    {
        PlayerOne = playerOne;
        PlayerTwo = playerTwo;

        if (rounds % 2 == 0)
        {
            throw new ArgumentException("An even number of rounds can lead to draws.");
        }

        Rounds = rounds;
    }

    public RPSPlayer PlayerOne { get; }
    public RPSPlayer PlayerTwo { get; }
    public int Rounds { get; }
    public List<RPSPlayer> MatchHistory { get; private set; } = [];

    public void Run()
    {
        Console.Clear();

        Console.WriteLine("The game begins! Draws do not count and those rounds are played again.");
        for (int i = 0; i < Rounds; i++)
        {
            Console.WriteLine($"Round {i}.");
            RPSPlayer? winner = ResolveRound();

            if (winner != null)
            {
                Console.WriteLine($"The winner of this round is {winner.Name}!");

                MatchHistory.Add(winner);
            }
            else
            {
                // When the winner is null this means there was a draw. Draws don't count towards the played rounds count.
                i--;
            }
        }

        int playerOneWins = MatchHistory.Count(x => x == PlayerOne);
        int playerTwoWins = MatchHistory.Count(x => x == PlayerTwo);

        Console.WriteLine($"The winner of this game is: {(playerOneWins > playerTwoWins ? PlayerOne.Name : PlayerTwo.Name)}!!!");
    }

    private RPSPlayer? ResolveRound()
    {
        RPSAttackType playerOneAttackType = GetAttackTypeChoice(PlayerOne);
        RPSAttackType playerTwoAttackType = GetAttackTypeChoice(PlayerTwo);

        if (playerOneAttackType == playerTwoAttackType)
        {
            Console.WriteLine("It's a draw!");

            return null;
        }

        return (playerOneAttackType, playerTwoAttackType) switch
        {
            (RPSAttackType.Paper, RPSAttackType.Rock) => PlayerOne,
            (RPSAttackType.Rock, RPSAttackType.Scissors) => PlayerOne,
            (RPSAttackType.Scissors, RPSAttackType.Paper) => PlayerOne,
            _ => PlayerTwo
        };
    }

    private RPSAttackType GetAttackTypeChoice(RPSPlayer player)
    {
        Console.WriteLine($"{player.Name}, it's your turn. What attack would you like to make?");
        RPSAttackType attackType = InputHelper.GetChoiceFromEnum<RPSAttackType>();

        Console.Clear();

        return attackType;
    }
}
