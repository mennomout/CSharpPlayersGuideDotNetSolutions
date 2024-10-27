using Challenges;

namespace ChallengesPart1Level3;

public class HelloWorldChallenge() : Challenge("Hello World")
{
    public override void Run(object[]? parameters = null)
    {
        Console.WriteLine("Hello, World!");
    }
}
