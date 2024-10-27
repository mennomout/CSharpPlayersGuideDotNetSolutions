using Helpers;

namespace Challenges.Part_2.Level_24;

public class Door
{
    private int _passcode;

    public Door(int passcode)
    {
        if (passcode == default)
        {
            throw new ArgumentException("The passcode you entered was invalid");
        }

        _passcode = passcode;
    }

    public DoorState State { get; private set; }

    public void UseDoor(string? input)
    {
        if (input == null)
        {
            Console.WriteLine("Your input was invalid. Try again");

            return;
        }

        if (input.Contains("change passcode", StringComparison.OrdinalIgnoreCase))
        {
            var newPasscode = input.Split(',', StringSplitOptions.TrimEntries)?.Last();

            if (int.TryParse(newPasscode, out int code))
            {
                _passcode = code;
            }
        }

        State = (input, State) switch
        {
            ("open", DoorState.Closed) => DoorState.Open,
            ("close", DoorState.Open) => DoorState.Closed,
            ("unlock", DoorState.Locked) => UnlockDoor(),
            ("lock", DoorState.Closed) => DoorState.Locked,
            _ => State
        };
    }

    private DoorState UnlockDoor()
    {
        Console.WriteLine("In order to unlock the door you need to enter the correct passcode:");

        int passcode = InputHelper.GetInputOrDefault<int>();

        if (passcode != _passcode)
        {
            Console.WriteLine("That was the wrong passcode!");

            return DoorState.Locked;
        }

        return DoorState.Closed;
    }
}
