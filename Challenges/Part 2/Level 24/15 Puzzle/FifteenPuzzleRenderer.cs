namespace Challenges.Part_2.Level_24._15_Puzzle;

public class FifteenPuzzleRenderer
{
    private readonly FifteenPuzzle fifteenPuzzle;

    public FifteenPuzzleRenderer(FifteenPuzzle fifteenPuzzle)
    {
        this.fifteenPuzzle = fifteenPuzzle;
    }

    public void Render()
    {
        int count = 0;
        for (int x = 0; x < fifteenPuzzle.Xaxis; x++)
        {
            for (int y = 0; y < fifteenPuzzle.YAxis; y++)
            {
                var value = fifteenPuzzle.Numbers[count];
                Console.Write(value == null ? " " : value);

                count++;
            }

            Console.WriteLine();
        }
    }
}
