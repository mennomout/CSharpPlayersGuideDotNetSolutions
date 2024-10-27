using Helpers;
using System.Diagnostics.Contracts;

namespace Challenges.Part_2.Level_24._15_Puzzle;

public class FifteenPuzzleChallenge() : Challenge("15-Puzzle")
{
    public override void Run(object[]? parameters = null)
    {
        Console.WriteLine("Welcome to 'Fifteen'-Puzzle, how big would you like your puzzle to be?");
        int x = InputHelper.GetInputOrDefault<int>("X-axis lenght");
        int y = InputHelper.GetInputOrDefault<int>("Y-axis lenght");

        FifteenPuzzleFactory factory = new(x, y);
        FifteenPuzzle puzzle = factory.GeneratePuzzle();
        FifteenPuzzleRenderer renderer = new(puzzle);

        Console.Clear();

        bool isIlligalMove = false;

        while (!puzzle.IsSolved)
        {
            if (isIlligalMove)
            {
                Console.WriteLine("You can't move that square");

                isIlligalMove = false;
            }
            
            renderer.Render();

            if (!puzzle.Move(InputHelper.GetNumberInRange("Enter the number of the square you want to move", 1, puzzle.Numbers.Length)))
            {
                isIlligalMove = true;
            }

            Console.Clear();
        }
    }
}
