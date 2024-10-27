using Helpers;

namespace Challenges.Part_1.Level_13;

public class TakingANumberChallenge() : Challenge("Taking a Number")
{
    public override void Run(object[]? parameters = null)
    {
        int number = AskForNumber("What is the airspeed velocity\r\nof an unladen swallow?");
        int secondNumber = AskForNumberInRange("Enter a number between 1 and 100", 1, 100);
    }

    public int AskForNumber(string text)
    {
        Console.WriteLine(text);

        return InputHelper.GetInputOrDefault<int>();
    }

    public int AskForNumberInRange(string text, int min, int max)
    {
        Console.WriteLine(text);

        int i = InputHelper.GetInputOrDefault<int>();

        while (i < min || i > max) i = AskForNumberInRange("That number is not within the correct range, try again.", min, max);

        return i;
    }
}
