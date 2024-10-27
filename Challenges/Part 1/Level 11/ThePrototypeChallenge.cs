using Helpers;

namespace Challenges.Part_1.Level_11;

public class ThePrototypeChallenge() : Challenge("The Prototype")
{
    public override void Run(object[]? parameters = null)
    {
        Console.Write("Hello player one, please entere a number between 0 and 100: ");
        int numberToGuess = InputHelper.GetInputOrDefault<int>();

        while (numberToGuess < 0 || numberToGuess > 100)
        {
            Console.Write("That number is not between 0 and 100. Enter another number: ");
            numberToGuess = InputHelper.GetInputOrDefault<int>();
        }

        Console.Clear();
        Console.Write("Hello player two, please guess the number player one has provided: ");
        int guess = InputHelper.GetInputOrDefault<int>();

        while (guess != numberToGuess)
        {
            Console.WriteLine("That guess was incorrect");
            Console.WriteLine($"The number you guessed was too {(guess > numberToGuess ? "high" : "low")}!");
            Console.Write("Try again: ");
            guess = InputHelper.GetInputOrDefault<int>();
        }

        Console.WriteLine("You guessed the number!");
    }
}
