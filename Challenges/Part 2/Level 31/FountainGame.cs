using Challenges.Part_2.Level_31.Rooms;
using Helpers;
using Helpers.Global_Enums;

namespace Challenges.Part_2.Level_31;

public class FountainGame
{
    private readonly Dungeon _dungeon;
    private readonly Adventurer _adventurer;

    public FountainGame(SizeEnum sizeEnum)
    {
        var axisLenght = GetGridAxesLenght(sizeEnum);
        _dungeon = new(axisLenght, axisLenght);
        _dungeon.SeedRooms(sizeEnum);
        _adventurer = new();
    }

    public void Run()
    {
        FountainRoom? fountainRoom = _dungeon.GetFountainRoom();
        
        if (fountainRoom == null)
        {
            Console.WriteLine("Something went wrong and the dungeon was not configured properly. No fountain room was created during initialisation of the dungeon or it could not be found.");

            return;
        }

        while (!fountainRoom.IsActivated && !_adventurer.IsDeath)
        {
            Console.Clear();

            if (_dungeon.GetPlayerRoom() is BaseRoom room)
            {
                Console.WriteLine($"Your position: {_dungeon.GetPlayerCoordinates()}");
                room.Enter(_dungeon);
                Console.WriteLine(room.Description);

                if (room is PitRoom || room is AmarokRoom)
                {
                    break;
                }

                PrintWarnings(_dungeon.GetAdjacentRooms(room));

                int nextRoomIndex = _adventurer.GetNextRoomByMoveDirection(_dungeon);

                while (!_dungeon.IsLegalMove(room, nextRoomIndex))
                {
                    Console.WriteLine("You cannot move there, try another direction.");

                    nextRoomIndex = _adventurer.GetNextRoomByMoveDirection(_dungeon);
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

        if (adjacentRooms.Any(x => x is MaelstromRoom))
        {
            Console.WriteLine("You hear the growling and groaning of a maelstrom nearby.");
        }
    }

    private int GetGridAxesLenght(SizeEnum size) => size switch
    {
        SizeEnum.Small => 4,
        SizeEnum.Medium => 6,
        SizeEnum.Large => 8
    };

}
