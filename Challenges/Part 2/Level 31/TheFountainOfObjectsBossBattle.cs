namespace Challenges.Part_2.Level_31;

public class TheFountainOfObjectsBossBattle() : Challenge("The Fountain of Objects (Boss Battle)")
{
    public override void Run(object[]? parameters = null)
    {

    }
}

// this approach without a multi dimensional array seems much more complex
// after initialisation it should be easy to work with however
// though what if a room changes position? maybe just change the type?
// the type is not decalred inside the room, but since we work with the abstract parent...
// if it changes position then another room changes as well
// what if both rooms simply become another type without their base class properties changing at all
public class Dungeon
{
    public List<Room> Rooms { get; set; } = [];

    public Dungeon(int x, int y)
    {
        for (int yAxis = 0; yAxis < y; yAxis++)
        {
            for (int xAxis = 0; xAxis < x; xAxis++)
            {
                Rooms.Add(new(new(xAxis, yAxis)));
            }
        }

        foreach (var room in Rooms)
        {
        }
    }
}

public class Room(Coordinates coordinates)
{
    private readonly List<Room> _adjacentRooms = [];

    public Room(Coordinates coordinates, List<Room> adjacentRooms) : this(coordinates)
    {
        Coordinates = coordinates;
        _adjacentRooms = adjacentRooms;
    }

    public Coordinates Coordinates { get; } = coordinates;
}

public record Coordinates(int X, int Y);
