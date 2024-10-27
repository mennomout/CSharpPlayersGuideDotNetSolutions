using Helpers;

namespace Challenges.Part_1.Level_12;

public class TheReplicatorOfDToChallenge() : Challenge("The Replicator of D'To")
{
    public override void Run(object[]? parameters = null)
    {
        int[] numbers = new int[5];

        Console.WriteLine($"Please enter {numbers.Length} numbers:");
        
        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = InputHelper.GetInputOrDefault<int>();
        }

        int[] numbersCopy = new int[numbers.Length];

        for (int i = 0; i < numbers.Length; i++)
        {
            numbersCopy[i] = numbers[i];

            Console.WriteLine($"Index {i}. Original array value: {numbers[i]} | Copy array value: {numbersCopy[i]}.");
        }
    }
}
