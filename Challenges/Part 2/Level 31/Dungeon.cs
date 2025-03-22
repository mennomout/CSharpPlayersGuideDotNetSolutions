using Challenges.Part_2.Level_31.Rooms;
using Helpers.Extensions;

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
                Rooms.Add(new EmptyRoom());
            }
        }
    }

    public int XLenght { get; init; }
    public int YLenght { get; init; }
    public List<BaseRoom> Rooms { get; private set; } = [];
    public int PlayerPosition { get; private set; }

    public BaseRoom? GetPlayerRoom()
    {
        if (!IsInBounds(PlayerPosition))
        {
            return null;
        }

        return Rooms[PlayerPosition];
    }

    public FountainRoom? GetFountainRoom() => Rooms.FirstOrDefault(x => x is FountainRoom) as FountainRoom;

    public bool IsInBounds(int index) => index >= 0 && index < Rooms.Count;

    // This is bugged. GetAdjacentRooms also returns rooms that are diagonal but those are not legal to move to. It's not a big issue since the input should not allow for diagonal choices at the moment.
    public bool IsLegalMove(BaseRoom currentRoom, int index) => IsInBounds(index) && GetAdjacentRooms(currentRoom).Contains(Rooms[index]);

    public bool TryMovePlayer(int newPlayerPosition)
    {
        if (!IsInBounds(newPlayerPosition))
        {
            return false;
        }

        PlayerPosition = newPlayerPosition;

        return true;
    }

    public bool TryFindRoomByType(Type type, out BaseRoom? room)
    {
        room = Rooms.FirstOrDefault(x => x.GetType() == type);

        return room != null;
    }

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

    public void SeedRooms(SizeEnum sizeEnum)
    {
        Rooms[0] = new EntryRoom();
        Rooms[Rooms.Count / 2] = new FountainRoom();

        int seedCount = sizeEnum switch
        {
            SizeEnum.Small => 1,
            SizeEnum.Medium => 2,
            SizeEnum.Large => 4
        };

        for (int i = 0; i < seedCount; i++)
        {
            SeedRoom<PitRoom>(new());
            SeedRoom<AmarokRoom>(new());
        }
    }

    // My original code
    //private void SeedRoom<T>(T room) where T : BaseRoom
    //{
    //    var randomIndex = Random.Shared.Next(1, Rooms.Count);
    //    var randomRoom = Rooms[randomIndex];

    //    while (randomRoom is not EmptyRoom || !Rooms.Any(x => x is EmptyRoom))
    //    {
    //        randomIndex = Random.Shared.Next(1, Rooms.Count);
    //        randomRoom = Rooms[randomIndex];
    //    }

    //    Rooms[randomIndex] = room;
    //}

    // Code suggested by ChatGPT. Actually a big improvement.
    private void SeedRoom<T>(T room) where T : BaseRoom
    {
        var emptyRoomIndices = Rooms
            .Select((r, i) => new { Room = r, Index = i })
            .Where(x => x.Room is EmptyRoom)
            .Select(x => x.Index)
            .ToList();

        if (emptyRoomIndices.Count == 0) return; 

        int randomIndex = Random.Shared.Next(emptyRoomIndices.Count);
        Rooms[emptyRoomIndices[randomIndex]] = room;
    }
}

