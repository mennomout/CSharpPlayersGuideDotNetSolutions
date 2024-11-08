namespace Challenges.Part_2.Level_28;

public class RoomCoordinatesChallenge() : Challenge("Room Coordinates")
{
    public override void Run(object[]? parameters = null)
    {
        Coordinate oneOne = new(1, 1);
        Coordinate oneTwo = new(1, 2);
        Coordinate threeThree = new(3, 3);
        Coordinate fourOne = new(4, 1);

        if (oneOne.IsAdjacent(oneTwo))
        {
            Console.WriteLine($"Coordinate {oneOne.X}, {oneOne.Y} is next to Coordinate {oneTwo.X}, {oneTwo.Y}");
        }

        if (threeThree.IsAdjacent(fourOne))
        {
            Console.WriteLine($"Coordinate {threeThree.X}, {threeThree.Y} is next to Coordinate {fourOne.X}, {fourOne.Y}");
        }   
    }
}

public readonly struct Coordinate(int x, int y)
{
    public int X { get; } = x;
    public int Y { get; } = y;

    public bool IsAdjacent(Coordinate coordinate) =>
        this.X - 1 == coordinate.X ||
        this.X + 1 == coordinate.X ||
        this.Y - 1 == coordinate.Y ||
        this.Y + 1 == coordinate.Y;
}
