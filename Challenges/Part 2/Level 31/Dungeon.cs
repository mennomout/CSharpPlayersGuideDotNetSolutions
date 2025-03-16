using Challenges.Part_2.Level_31.Rooms;
using Helpers;

namespace Challenges.Part_2.Level_31;

public class Dungeon
{
    public Dungeon(int x, int y)
    {
        XLenght = x;
        YLenght = y;

        for (int yAxis = 0; yAxis < y; yAxis++)
        {
            for (int xAxis = 0; xAxis < x; xAxis++)
            {
                if (xAxis == 0 && yAxis == 0)
                {
                    Rooms.Add(new EntryRoom());
                }
                else if (xAxis == (x - 1) / 2 && yAxis == (y - 1) / 2)
                {
                    Rooms.Add(new FountainRoom());
                }
                else
                {
                    Rooms.Add(new EmptyRoom());
                }
            }
        }
    }


    public int XLenght { get; init; }
    public int YLenght { get; init; }
    public List<BaseRoom> Rooms { get; private set; } = [];

    public BaseRoom? GetRoom(int index) => IsInBounds(index) ? Rooms[index] : null;

    public bool TryFindRoomByType(Type type, out BaseRoom? room)
    {
        room = Rooms.FirstOrDefault(x => x.GetType() == type);

        return room != null;
    }

    public bool IsInBounds(int index) => index >= 0 && index < Rooms.Count;

    public IList<BaseRoom> GetAdjacentRooms(BaseRoom room)
    {
        var index = Rooms.IndexOf(room);
        var adjacentRooms = new List<BaseRoom>();
         
        // Left room 
        if (index - 1 >= 0 && index.IsRemainderNotZero(XLenght)) adjacentRooms.Add(Rooms[index - 1]);

        // Right room
        if (index + 1 < Rooms.Count && (index + 1).IsRemainderNotZero(XLenght)) adjacentRooms.Add(Rooms[index + 1]);

        // Bottom room
        if (index + XLenght < Rooms.Count)
        {
            adjacentRooms.Add(Rooms[index + XLenght]);

            // Bottom left room
            if ((index + XLenght).IsRemainderNotZero(XLenght)) adjacentRooms.Add(Rooms[index + (XLenght - 1)]);

            // Bottom right room
            if ((index + 1 + XLenght) < Rooms.Count && (index + 1 + XLenght).IsRemainderNotZero(XLenght)) adjacentRooms.Add(Rooms[index + (XLenght + 1)]);
        }

        // Top room
        if (index - XLenght >= 0) 
        {
            adjacentRooms.Add(Rooms[index - XLenght]);

            // Top left room. 
            if (index - (XLenght + 1) >= 0 && (index - XLenght).IsRemainderNotZero(XLenght)) adjacentRooms.Add(Rooms[index - (XLenght + 1)]);
            
            // Top right room. 
            if ((index - (XLenght - 1)).IsRemainderNotZero(XLenght)) adjacentRooms.Add(Rooms[index - (XLenght - 1)]);
        }

        return adjacentRooms;
    }
}

