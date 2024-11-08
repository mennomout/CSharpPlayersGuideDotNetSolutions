using Helpers;

namespace Challenges.Part_2.Level_27;

public class RoboticInterfaceChallenge() : Challenge("Robotic Interface")
{
    // Question: Do you feel this is an improvement over using an abstract base class? Why or why not?
    // Answer: I think if the program became bigger the interface offers more flexebility. 
    public override void Run(object[]? parameters = null)
    {
        Console.WriteLine("Enter three commands for the robobt:");

        List<IRobotCommand?> commands = [];

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

public class Robot(IEnumerable<IRobotCommand?> commands)
{
    public int X { get; set; }
    public int Y { get; set; }
    public bool IsPowered { get; set; }
    public IRobotCommand?[] Commands { get; } = commands.ToArray();

    public void Run()
    {
        foreach (IRobotCommand? command in Commands)
        {
            command?.Run(this);
            Console.WriteLine($"[{X} {Y} {IsPowered}]");
        }
    }
}

public interface IRobotCommand
{
    void Run(Robot robot);
}

public class OnCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        robot.IsPowered = true;
    }
}

public class OffComand : IRobotCommand
{
    public void Run(Robot robot)
    {
        robot.IsPowered = false;
    }
}

public class NorthCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        if (robot.IsPowered)
        {
            robot.Y++;
        }
    }
}

public class SouthCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        if (robot.IsPowered)
        {
            robot.Y--;
        }
    }
}

public class WestCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        if (robot.IsPowered)
        {
            robot.X--;
        }
    }
}

public class EastCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        if (robot.IsPowered)
        {
            robot.X++;
        }
    }
}

