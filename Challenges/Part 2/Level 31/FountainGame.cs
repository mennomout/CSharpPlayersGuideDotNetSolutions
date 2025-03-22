using Challenges.Part_2.Level_31.Rooms;
using Helpers;
using Helpers.Global_Enums;

namespace Challenges.Part_2.Level_31;

public class FountainGame
{
    private readonly Dungeon _dungeon;

    public FountainGame(SizeEnum sizeEnum)
    {
        var axisLenght = GetGridAxesLenght(sizeEnum);
        _dungeon = new(axisLenght, axisLenght);
        _dungeon.SeedRooms(sizeEnum);
    }

    public void Run()
    {
        FountainRoom? fountainRoom = _dungeon.GetFountainRoom();
        
        if (fountainRoom == null)
        {
            Console.WriteLine("Something went wrong and the dungeon was not configured properly. No fountain room was created during initialisation of the dungeon or it could not be found.");

            return;
        }

        while (!fountainRoom.IsActivated)
        {
            Console.Clear();

            if (_dungeon.GetPlayerRoom() is BaseRoom room)
            {
                Console.WriteLine($"Your position: ");
                room.Enter(_dungeon);
                Console.WriteLine(room.Description);

                if (room is PitRoom || room is AmarokRoom)
                {
                    break;
                }

                PrintWarnings(_dungeon.GetAdjacentRooms(room));

                int nextRoomIndex = GetNextRoomByMoveDirection(_dungeon);

                while (!_dungeon.IsLegalMove(room, nextRoomIndex))
                {
                    Console.WriteLine("You cannot move there, try another direction.");

                    nextRoomIndex = GetNextRoomByMoveDirection(_dungeon);
                }

                _dungeon.TryMovePlayer(nextRoomIndex);
            }    
        }
    }

    private void PrintWarnings(IList<BaseRoom> adjacentRooms)
    {
        if (adjacentRooms.Any(x => x is PitRoom))
        {
            Console.WriteLine("You feel a draft. There is a pit in a nearby room.");
        }

        if (adjacentRooms.Any(x => x is AmarokRoom))
        {
            Console.WriteLine("You can smell the rotten stench of an Amarok in a nearby room.");
        }
    }

    private int GetGridAxesLenght(SizeEnum size) => size switch
    {
        SizeEnum.Small => 4,
        SizeEnum.Medium => 6,
        SizeEnum.Large => 8
    };

    private int GetNextRoomByMoveDirection(Dungeon dungeon)
    {
        var direction = InputHelper.GetChoiceFromEnum<DirectionEnum>();

        return direction switch
        {
            DirectionEnum.Up => dungeon.PlayerPosition - dungeon.XLenght,
            DirectionEnum.Down => dungeon.PlayerPosition + dungeon.XLenght,
            DirectionEnum.Left => dungeon.PlayerPosition - 1,
            DirectionEnum.Right => dungeon.PlayerPosition + 1,
        };
    }
}
