

using Helpers;

namespace Challenges.Part_2.Level_32;

public class TheRobotPilotChallenge() : Challenge("The Robot Pilot")
{
    public override void Run(object[]? parameters = null)
    {
        int round = 1;
        int manticoreHealth = 10;
        int cityHealth = 15;
        int manticoreDistance = Random.Shared.Next(0, 101);
        bool isManticoreDeath = false;

        Console.Clear();
        Console.WriteLine("This is a modified version from the original Hunting the Manticor solution. A random number is picked by using the random class.");
        Console.WriteLine("One way to get two implemenations of a solution is by using interfaces with different logic for specific methods.");
        Console.WriteLine("Here a member of the interface could be the method for selecting the distance of the manticore.");
        Console.WriteLine("Then inherit from a base implementation but let the method for selecting the distance be determined by the specific implemenation e.g. Hunting the Manticore A.I. or Hunting the Manticore Multiplayer.");
        Console.WriteLine();
        DisplayHelper.DisplayColoredText("Player, it's now up to you. Shoot down the Manticore or Consolas will be lost forever!", ConsoleColor.Green);

        while (cityHealth > 0)
        {
            DisplayStatus(round, cityHealth, manticoreHealth);

            if (TryHitManticore(manticoreDistance))
            {
                manticoreHealth -= GetDamage(round);

                if (manticoreHealth <= 0)
                {
                    isManticoreDeath = true;
                    break;
                }
            }

            cityHealth--;
            round++;
        }

        if (isManticoreDeath)
        {
            DisplayHelper.DisplayColoredText("The Manticore has been destroyed! The City of Consolas has been saved!", ConsoleColor.Green);
        }
        else
        {
            DisplayHelper.DisplayColoredText("The City of Consolas has fallen to the might of the Manticore.", ConsoleColor.DarkRed);
        }
    }

    private bool TryHitManticore(int manticoreDistance)
    {
        int range = InputHelper.GetNumberInRange("Enter desired cannon range (between 0 and 100)", 1, 100);

        DisplayHelper.DisplayColoredText($"That round {(range > manticoreDistance ? "OVERSHOT the target" : range < manticoreDistance ? "FELL SHORT of the target" : "was a DIRECT HIT")}", ConsoleColor.Red);

        return range == manticoreDistance;
    }

    private void DisplayStatus(int round, int cityHealth, int manticoreHealth)
    {
        Console.WriteLine($"Round: {round}  City: {cityHealth}/15  Manticore: {manticoreHealth}/10");
        Console.WriteLine($"The cannon is expected to deal {GetDamage(round)} damage this round.");
    }

    private int GetDamage(int round)
    {
        if (round % 3 == 0 && round % 5 == 0) return 10;
        else if (round % 5 == 0 || round % 3 == 0) return 3;

        return 1;
    }
}
