using Challenges.Part_2.Level_19;
using Helpers;

namespace Challenges.Part_2.Level_21;

public class ArrowFactoriesChallenge() : Challenge("Arrow Factories")
{
    public override void Run(object[]? parameters = null)
    {
        string? choice = InputHelper.GetInputOrDefault<string>("Would you like a custom arrow or pre-defined?");

        if (!string.IsNullOrWhiteSpace(choice))
        {
            if (choice.Equals("custom", StringComparison.OrdinalIgnoreCase))
            {
                Arrow arrow = new();
            }
            else
            {
                Console.WriteLine("Choose one of these pre-defined options:");
                string? arrowType = InputHelper.GetRequiredInput(["Elite", "Beginner", "Marksman"]);

                Arrow arrow = arrowType switch
                {
                    "Elite" => Arrow.GetEliteArrow(),
                    "Beginner" => Arrow.GetBeginnerArrow(),
                    "Marksman" => Arrow.GetMarksmanArrow(),
                };
            }
        }
    }
}
