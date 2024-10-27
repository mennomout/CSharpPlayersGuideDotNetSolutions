namespace Challenges.Part_1.Level_12;

public class TheLawsOfFreachChallenge() : Challenge("The Laws of Freach")
{
    public override void Run(object[]? parameters = null)
    {
        int[] array = [4, 51, -7, 13, -99, 15, -8, 45, 90];
        int currentSmallest = int.MaxValue; // Start higher than anything in the array.
        int total = 0;

        foreach (int number in array)
        {
            if (number < currentSmallest)
                currentSmallest = number;

            total += number;
        }

        float average = (float)total / array.Length;
        
        Console.WriteLine($"The smallest numer is: {currentSmallest} and the average is {average}.");
    }
}
