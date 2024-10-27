using Helpers;

namespace Challenges.Part_1.Level_7;

public class TheDominionOfKingsChallenge() : Challenge("The Dominion of Kings")
{
    public override void Run(object[]? parameters = null)
    {
        Console.WriteLine("Enter the number of provinces, duchies and estates you have in that order:");
        int provinces = InputHelper.GetInputOrDefault<int>();
        int duchies = InputHelper.GetInputOrDefault<int>();
        int estates = InputHelper.GetInputOrDefault<int>();

        Console.WriteLine($"Your points total is: {estates + duchies * 3 + provinces * 6}");
    }
}
