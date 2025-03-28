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

        do
        {
            Console.Clear();
            Console.WriteLine($"Your position: {_dungeon.GetCoordinates(_adventurer.Position)}");
            Console.WriteLine($"You have {_adventurer.ArrowCount} arrows in your quiver.");

            // This order is not correct in combination with the GetAdventurerInput method.
            if (_dungeon.GetRoom(_adventurer.Position) is BaseRoom room)
            {
                Console.WriteLine(room.Description);
                room.Enter(_dungeon, _adventurer);

                if (GameEnded(fountainRoom))
                {
                    break;  
                }

                var adjacentRooms = _dungeon.GetAdjacentRooms(_adventurer.Position);
                PrintWarnings(adjacentRooms);
                GetAdventurerInput(adjacentRooms);
            }
        } while (!GameEnded(fountainRoom));
    }

    private bool GameEnded(FountainRoom fountainRoom) => fountainRoom.IsActivated || _adventurer.IsDeath;

    
    private void GetAdventurerInput(IList<BaseRoom> adjacentRooms)
    {
        if (adjacentRooms.Any(x => x is AmarokRoom a && !a.IsDeath))
        {
            Console.WriteLine("Do you wish to use your bow and shoot an arrow?");

            var choice = InputHelper.GetRequiredInput(["yes", "no"])?.ToLower();

            if (!string.IsNullOrWhiteSpace(choice) && choice == "yes")
            {
                var directionIndex = GetIndexByDirectionInput(_adventurer.Position);

                if (_dungeon.Rooms[directionIndex] is AmarokRoom amarokRoom)
                {
                    amarokRoom.Hit();
                    Console.WriteLine("You hear a scream!");
                }
            }
        }

        int nextRoomIndex = GetIndexByDirectionInput(_adventurer.Position);

        _adventurer.Move(nextRoomIndex);
    }

    private int GetIndexByDirectionInput(int currentRoomIndex)
    {
        var roomIndex = InputHelper.GetChoiceFromEnum<DirectionEnum>() switch
        {
            DirectionEnum.Up => _adventurer.Position - _dungeon.XLenght,
            DirectionEnum.Down => _adventurer.Position + _dungeon.XLenght,
            DirectionEnum.Left => _adventurer.Position - 1,
            DirectionEnum.Right => _adventurer.Position + 1,
        };

        if (!_dungeon.IsLegalMove(currentRoomIndex, roomIndex))
        {
            Console.WriteLine("That is not a valid direction.");

            return GetIndexByDirectionInput(currentRoomIndex);
        }

        return roomIndex;
    }

    private void PrintWarnings(IList<BaseRoom> adjacentRooms)
    {
        if (adjacentRooms.Any(x => x is PitRoom))
        {
            Console.WriteLine("You feel a draft. There is a pit in a nearby room.");
        }

        if (adjacentRooms.Any(x => x is AmarokRoom amarokRoom && !amarokRoom.IsDeath))
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
