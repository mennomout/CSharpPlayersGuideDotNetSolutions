namespace Challenges.Part_2.Level_24._15_Puzzle;

public class FifteenPuzzleFactory
{
    public FifteenPuzzleFactory(int xAxisLenght, int yAxisLenght)
    {
        XAxisLenght = xAxisLenght;
        YAxisLenght = yAxisLenght;
    }

    public int XAxisLenght { get; }
    public int YAxisLenght { get; }

    public FifteenPuzzle GeneratePuzzle()
    {
        Random random = new();
        int numberCount = XAxisLenght * YAxisLenght;
        int numberToSkip = random.Next(1, numberCount);
        List<int?> numbers = [];

        for (int i = 1; i < numberCount; i++)
        {
            numbers.Add(i);
        }

        numbers.Add(null);

        return new(numbers.OrderBy(_ => Guid.NewGuid()).ToArray(), XAxisLenght, YAxisLenght);
    }
}
