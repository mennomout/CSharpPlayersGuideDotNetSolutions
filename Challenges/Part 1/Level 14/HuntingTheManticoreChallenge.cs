using Helpers;

namespace Challenges.Part_1.Level_14;

public class HuntingTheManticoreChallenge() : Challenge("Hunting the Manticore")
{
    public override void Run(object[]? parameters = null)
    {
        int round = 1;
        int manticoreHealth = 10;
        int cityHealth = 15;
        int manticoreDistance = InputHelper.GetNumberInRange("Player 1, how far away from the city do you want to station the Manticore? (between 0 and 100)", 0, 100);
        bool isManticoreDeath = false;


        Console.Clear();
        DisplayHelper.DisplayColoredText("Player 2, it's now up to you. Shoot down the Manticore or Consolas will be lost forever!", ConsoleColor.Green);

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