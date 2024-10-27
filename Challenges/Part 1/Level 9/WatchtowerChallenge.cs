using Helpers;

namespace Challenges.Part_1.Level_9;

public class WatchtowerChallenge() : Challenge("Watchtower")
{
    public override void Run(object[]? parameters = null)
    {
        Console.WriteLine("Please enter an X and Y value (integer) in that order:");
        int x = InputHelper.GetInputOrDefault<int>();
        int y = InputHelper.GetInputOrDefault<int>();

        if (y > 0)
        {
            if (x < 0) Console.WriteLine("NW");
            else if (x == 0) Console.WriteLine("N");
            else Console.WriteLine("NE");
        }
        else if (y == 0)
        {
            if (x < 0) Console.WriteLine("W");
            else if (x == 0) Console.WriteLine("!");
            else Console.WriteLine("E");
        }
        else
        {
            if (x < 0) Console.WriteLine("SW");
            else if (x == 0) Console.WriteLine("S");
            else Console.WriteLine("SE");
        }
    }
}
