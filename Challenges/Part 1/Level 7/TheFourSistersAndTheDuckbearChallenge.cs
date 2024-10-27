using Helpers;

namespace Challenges.Part_1.Level_7;

public class TheFourSistersAndTheDuckbearChallenge() : Challenge("The Four Sisters and the Duckbear")
{
    public override void Run(object[]? parameters = null)
    {
        Console.Write("Please enter the number of chocolate eggs that were collected today: ");
        int daysChocolateEggs = InputHelper.GetInputOrDefault<int>();
        Console.WriteLine(GetLeftOverEggCount(daysChocolateEggs));

        List<int> duckbearHasMoreEggsThenSisters = [];
        int increment = 1;

        while (duckbearHasMoreEggsThenSisters.Count < 3) 
        {
            if (GetLeftOverEggCount(increment) > increment / 4)
            {
                duckbearHasMoreEggsThenSisters.Add(increment);
            }

            increment++;
        }

        Console.WriteLine("These amount of eggs give the duckbear more then the sisters:");
        duckbearHasMoreEggsThenSisters.ForEach(x => Console.WriteLine(x));
    }

    private int GetLeftOverEggCount(int daysChocolateEggs, int numberOfSisters = 4 /*just in case...*/)
    {
        return daysChocolateEggs % numberOfSisters;
    }
}
