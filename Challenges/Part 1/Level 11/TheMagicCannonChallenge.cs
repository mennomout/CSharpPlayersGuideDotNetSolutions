using Helpers;

namespace Challenges.Part_1.Level_11;

public class TheMagicCannonChallenge() : Challenge("The Magic Cannon")
{
    public override void Run(object[]? parameters = null)
    {
        for (int i = 1; i <= 100; i++)
        {
            Console.Write($"{i}. ");

            if (i % 3 == 0 && i % 5 == 0) DisplayHelper.DisplayColoredText("Super Charged", ConsoleColor.Magenta);
            else if (i % 3 == 0) DisplayHelper.DisplayColoredText("Fire", ConsoleColor.Red);
            else if (i % 5 == 0) DisplayHelper.DisplayColoredText("Lightning", ConsoleColor.Blue);
            else DisplayHelper.DisplayColoredText("Normal", ConsoleColor.Gray);
        }
    }
}
