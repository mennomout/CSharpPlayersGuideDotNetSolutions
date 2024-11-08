using Helpers;

namespace Challenges.Part_2.Level_26;

public class TheOldRobotChallenge() : Challenge("The old Robot")
{
    public override void Run(object[]? parameters = null)
    {
        Console.WriteLine("Enter three commands for the robobt:");

        List<RobotCommand?> commands = [];

        for (int i = 0; i < 3; i++)
        {
            commands.Add(InputHelper.GetRequiredInput([
                nameof(OnCommand),
                nameof(OffComand),
                nameof(NorthCommand),
                nameof(EastCommand),
                nameof(SouthCommand),
                nameof(WestCommand)]) switch
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

public class Robot(IEnumerable<RobotCommand?> commands)
{
    public int X { get; set; }
    public int Y { get; set; }
    public bool IsPowered { get; set; }
    public RobotCommand?[] Commands { get; } = commands.ToArray();

    public void Run()
    {
        foreach (RobotCommand? command in Commands)
        {
            command?.Run(this);
            Console.WriteLine($"[{X} {Y} {IsPowered}]");
        }
    }
}

public abstract class RobotCommand
{
    public abstract void Run(Robot robot);
}

public class OnCommand : RobotCommand
{
    public override void Run(Robot robot)
    {
        robot.IsPowered = true;
    }
}

public class OffComand : RobotCommand
{
    public override void Run(Robot robot)
    {
        robot.IsPowered = false;
    }
}

public class NorthCommand : RobotCommand
{
    public override void Run(Robot robot)
    {
        if (robot.IsPowered)
        {
            robot.Y++;
        }
    }
}

public class SouthCommand : RobotCommand
{
    public override void Run(Robot robot)
    {
        if (robot.IsPowered)
        {
            robot.Y--;
        }
    }
}

public class WestCommand : RobotCommand
{
    public override void Run(Robot robot)
    {
        if (robot.IsPowered)
        {
            robot.X--;
        }
    }
}

public class EastCommand : RobotCommand
{
    public override void Run(Robot robot)
    {
        if (robot.IsPowered)
        {
            robot.X++;
        }
    }
}
