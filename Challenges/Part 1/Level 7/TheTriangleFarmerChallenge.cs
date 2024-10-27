using Challenges;
using Helpers;

namespace ChallengesPart1Level7;

public class TheTriangleFarmerChallenge() : Challenge("The Triangle Farmer")
{
    public override void Run(object[]? parameters = null)
    {
        Console.Write("Please enter the triangle height: ");
        double height = InputHelper.GetInputOrDefault<double>();

        Console.Write("Please enter the triagle base: ");
        double tBase = InputHelper.GetInputOrDefault<double>();
        
        Console.WriteLine($"Area = {tBase} * {height} / 2 = {tBase * height / 2}");    
    }
}
