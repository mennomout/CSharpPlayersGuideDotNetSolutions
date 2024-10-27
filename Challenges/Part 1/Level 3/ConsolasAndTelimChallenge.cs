using Challenges;

namespace ChallengesPart1Level3;

public class ConsolasAndTelimChallenge() : Challenge("Consolas and Telim")
{
    public override void Run(object[]? parameters = null)
    {
        Console.WriteLine("Bread is ready.");
        Console.WriteLine("Who is the bread for?");

        string? name = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine($"Noted: {name} got bread.");
        }
        else
        {
            Console.WriteLine("Sorry, the name provided is invalid");
        }
    }
}
