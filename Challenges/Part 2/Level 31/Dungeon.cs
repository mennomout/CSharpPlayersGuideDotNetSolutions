using Challenges.Part_2.Level_31.Rooms;

namespace Challenges.Part_2.Level_31;

public class Dungeon
{
    private int _xLenght;
    private int _yLenght;

    public Dungeon(int x, int y)
    {
        _xLenght = x;
        _yLenght = y;

        for (int yAxis = 0; yAxis < y; yAxis++)
        {
            for (int xAxis = 0; xAxis < x; xAxis++)
            {
                if (xAxis == 0 && yAxis == 0)
                {
                    Rooms.Add(new EntryRoom(new(xAxis, yAxis)));
                }
                else if (xAxis == (x - 1) / 2 && yAxis == (y - 1) / 2)
                {
                    Rooms.Add(new FountainRoom(new(xAxis, yAxis)));
                }
                else
                {
                    Rooms.Add(new EmptyRoom(new(xAxis, yAxis)));
                }
            }
        }
    }

    public List<BaseRoom> Rooms { get; set; } = [];

    public bool TryFindRoomByCoordinates(Coordinates coordinates, out BaseRoom? room)
    {
        room = Rooms.FirstOrDefault(x => x.Coordinates == coordinates);

        return room != null;
    }

    public bool TryFindRoomByType(Type type, out BaseRoom? room)
    {
        room = Rooms.FirstOrDefault(x => x.GetType() == type);

        return room != null;
    }

    public bool IsValidCoordinate(Coordinates coordinates) => coordinates.X >= 0 && coordinates.Y >= 0 && coordinates.X < _xLenght && coordinates.Y < _yLenght;
}

