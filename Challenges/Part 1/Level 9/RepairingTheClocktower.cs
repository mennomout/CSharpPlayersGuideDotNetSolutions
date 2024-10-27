using Helpers;

namespace Challenges.Part_1.Level_9;

public class RepairingTheClocktower() : Challenge("Repairing The Clocktower")
{
    public override void Run(object[]? parameters = null)
    {
        int input = InputHelper.GetInputOrDefault<int>();

        Console.WriteLine(input / 2 == 0 ? "Tick" : "Tock");
    }
}
