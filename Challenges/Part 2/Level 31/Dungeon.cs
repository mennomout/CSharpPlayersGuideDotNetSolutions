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
    public FountainRoom? FountainRoom => Rooms.FirstOrDefault(x => x is FountainRoom) as FountainRoom;

    public BaseRoom? GetRoom(int index)
    {
        if (!IsInBounds(index))
        {
            return null;
        }

        return Rooms[index];
    }

    public Coordinates GetCoordinates(int index) => new(index % XLenght, (int)Math.Floor((double)index / XLenght));

    public bool IsInBounds(int index) => index >= 0 && index < Rooms.Count;

    public bool IsLegalMove(int currentIndex, int moveIndex) => IsInBounds(moveIndex) && GetAdjacentRooms(currentIndex).Contains(Rooms[moveIndex]);

    public IList<BaseRoom> GetAdjacentRooms(int currentIndex)
    {
        var adjacentRooms = new List<BaseRoom>();

        // Left room 
        if (currentIndex - 1 >= 0 && currentIndex.IsRemainderNotZero(XLenght)) adjacentRooms.Add(Rooms[currentIndex - 1]);

        // Right room
        if (currentIndex + 1 < Rooms.Count && (currentIndex + 1).IsRemainderNotZero(XLenght)) adjacentRooms.Add(Rooms[currentIndex + 1]);

        // Bottom room
        if (currentIndex + XLenght < Rooms.Count)
        {
            adjacentRooms.Add(Rooms[currentIndex + XLenght]);

            // Bottom left room
            if ((currentIndex + XLenght).IsRemainderNotZero(XLenght)) adjacentRooms.Add(Rooms[currentIndex + (XLenght - 1)]);

            // Bottom right room
            if ((currentIndex + 1 + XLenght) < Rooms.Count && (currentIndex + 1 + XLenght).IsRemainderNotZero(XLenght)) adjacentRooms.Add(Rooms[currentIndex + (XLenght + 1)]);
        }

        // Top room
        if (currentIndex - XLenght >= 0)
        {
            adjacentRooms.Add(Rooms[currentIndex - XLenght]);

            // Top left room. 
            if (currentIndex - (XLenght + 1) >= 0 && (currentIndex - XLenght).IsRemainderNotZero(XLenght)) adjacentRooms.Add(Rooms[currentIndex - (XLenght + 1)]);

            // Top right room. 
            if ((currentIndex - (XLenght - 1)).IsRemainderNotZero(XLenght)) adjacentRooms.Add(Rooms[currentIndex - (XLenght - 1)]);
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
            SeedRoom<MaelstromRoom>(new());
            SeedRoom<PitRoom>(new());
            SeedRoom<AmarokRoom>(new());
        }
    }

    public void SeedRoom<T>(T room) where T : BaseRoom
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

