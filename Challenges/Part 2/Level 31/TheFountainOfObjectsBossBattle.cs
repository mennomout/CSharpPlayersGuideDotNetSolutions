using Challenges.Part_2.Level_31.Rooms;
using Helpers;
using Helpers.Global_Enums;

namespace Challenges.Part_2.Level_31;

public class TheFountainOfObjectsBossBattle() : Challenge("The Fountain of Objects Game")
{
    public override void Run(object[]? parameters = null)
    {
        Dungeon dungeon = new(4, 4);
        FountainRoom? fountainRoom = dungeon.GetFountainRoom();
        
        if (fountainRoom == null)
        {
            Console.WriteLine("Something went wrong and the dungeon was not configured properly. No fountain room was created during initialisation of the dungeon or it could not be found.");

            return;
        }

        while (!fountainRoom.IsActivated)
        {
            Console.Clear();

            if (dungeon.GetPlayerRoom() is BaseRoom room)
            {
                Console.WriteLine($"Your position: ");
                Console.WriteLine(room.Description);

                if (room is PitRoom)
                {
                    break;
                }

                room.Enter(dungeon);
                int nextRoomIndex = GetNextRoomIndex(dungeon);

                while (!dungeon.TryMovePlayer(nextRoomIndex))
                {
                    Console.WriteLine("You cannot move there, try another direction.");

                    nextRoomIndex = GetNextRoomIndex(dungeon);
                }
            }    
        }
    }

    private int GetNextRoomIndex(Dungeon dungeon)
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
