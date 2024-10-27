using Helpers;

namespace Challenges.Part_1.Level_8;

public class TheDefenceOfConsolasChallenge() : Challenge("The Defence of Consolas")
{
    public override void Run(object[]? parameters = null)
    {
        // TODO: change title of console to the curren challenge that is running.
        // TODO: Clear console between choosing a challenge and running it.
        Console.Title = "Defense of Consolas";

        Console.WriteLine("Enter the target row and column (in that order): ");
        int row = InputHelper.GetInputOrDefault<int>();
        int column = InputHelper.GetInputOrDefault<int>();

        Console.WriteLine("Deploy to:");
        Console.ForegroundColor = ConsoleColor.Green;
        
        Console.WriteLine($"{row - 1}, {column}");
        Console.WriteLine($"{row + 1}, {column}");
        Console.WriteLine($"{row}, {column - 1}");
        Console.WriteLine($"{row}, {column + 1}");

        Console.ResetColor();
        Console.Beep(440, 1000);

        Console.Title = "CSharpPlayersGuideDotNet";
    }
}
