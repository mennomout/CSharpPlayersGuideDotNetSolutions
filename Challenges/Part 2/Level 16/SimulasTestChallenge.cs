using Helpers;

namespace Challenges.Part_2.Level_16;

public class SimulasTestChallenge() : Challenge("Simula's Test")
{
    public override void Run(object[]? parameters = null)
    {
        ChestEnum state = ChestEnum.Locked;
        string? input = string.Empty;
        Console.WriteLine("There is a chest. You can manipulate it with the following commands: unlock, open, close and lock.");
        Console.WriteLine("You can quit any time by typing  the command 'stop'.");

        while (!input.Equals("stop", StringComparison.OrdinalIgnoreCase))
        {
            Console.Write($"The chest is {state.ToString().ToLower()}. What do you want to do? ");
            input = InputHelper.GetInputOrDefault<string>()?.ToLower();

            state = (input, state) switch
            {
                ("open", ChestEnum.Unlocked) => ChestEnum.Open,
                ("close", ChestEnum.Open) => ChestEnum.Unlocked,
                ("unlock", ChestEnum.Locked) => ChestEnum.Unlocked,
                ("lock", ChestEnum.Unlocked) => ChestEnum.Locked,
                _ => state
            };

            input ??= string.Empty;
        }
    }
}
