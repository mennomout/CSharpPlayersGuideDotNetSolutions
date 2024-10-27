using Helpers;

namespace Challenges.Part_2.Level_18;

public class VinFletchersArrowsChallenge() : Challenge("Vin Fletcher's Arrows")
{
    public override void Run(object[]? parameters = null)
    {
        Console.WriteLine("Build an arrow by giving the arrowhead type, fletching type and lenght:");

        Arrow arrow = new()
        {
            Arrowhead = InputHelper.GetChoiceFromEnum<Arrowhead>(),
            Fletching = InputHelper.GetChoiceFromEnum<Fletching>(),
            Lenght = InputHelper.GetNumberInRange("Please enter the lenght of the arrow shaft.", 60, 100)
        };

        Console.WriteLine($"This arrow costs {arrow.GetCost()} to build.");
    }
}
