using Helpers;

namespace Challenges.Part_2.Level_24;

public class TheLockedDoorChallenge() : Challenge("The Locked Door")
{
    public override void Run(object[]? parameters = null)
    {
        Console.WriteLine("There is a door. You can manipulate it with the following commands: unlock, open, close and lock. You can change the password with the command 'change passcode, *new code here*'.");
        Console.WriteLine("You can quit any time by typing  the command 'stop'.");

        Console.WriteLine("Please enter a starting passcode that is used to unlock the door:");
        Door door = null;

        while (door == null)
        {
            try
            {
                door = new(InputHelper.GetInputOrDefault<int>());
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);

                Console.WriteLine("Try a different passcode:");
            }
        }

        string? input = string.Empty;

        while (!input.Equals("stop", StringComparison.OrdinalIgnoreCase))
        {
            Console.Write($"The door is {door.State.ToString().ToLower()}. What do you want to do? ");
            input = InputHelper.GetInputOrDefault<string>()?.ToLower();

            door.UseDoor(input);

            if (input == null)
            {
                input = string.Empty;
            }
        }
    }
}