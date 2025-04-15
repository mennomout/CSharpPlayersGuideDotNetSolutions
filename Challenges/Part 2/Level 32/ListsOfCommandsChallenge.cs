using Challenges.Part_2.Level_27;
using Helpers;

namespace Challenges.Part_2.Level_32;

public class ListsOfCommandsChallenge() : Challenge("Lists of Commands")
{
    public override void Run(object[]? parameters = null)
    {
        Console.WriteLine("Enter three commands for the robobt:");

        List<IRobotCommand?> commands = [];

        while (true)
        {
            var input = InputHelper.GetRequiredInput([
                nameof(OnCommand),
                nameof(OffComand),
                nameof(NorthCommand),
                nameof(EastCommand),
                nameof(SouthCommand),
                nameof(WestCommand),
                "Stop"]);

            if (input != null && input.Equals("Stop", StringComparison.CurrentCultureIgnoreCase))
            {
                break;
            }

            commands.Add(input switch
            {
                nameof(OnCommand) => new OnCommand(),
                nameof(OffComand) => new OffComand(),
                nameof(NorthCommand) => new NorthCommand(),
                nameof(EastCommand) => new EastCommand(),
                nameof(SouthCommand) => new SouthCommand(),
                nameof(WestCommand) => new WestCommand(),
                _ => null
            });

            Console.Clear();
        }

        Robot robot = new(commands);
        robot.Run();
    }
}
