using Challenges.Part_2.Level_31.Rooms;
using Helpers;
using Helpers.Global_Enums;

namespace Challenges.Part_2.Level_31;

public class TheFountainOfObjectsBossBattle() : Challenge("The Fountain of Objects Game")
{
    public override void Run(object[]? parameters = null)
    {
        Dungeon dungeon = new(4, 4);
        int playerPosition = 0;
        
        if (!dungeon.TryFindRoomByType(typeof(FountainRoom), out BaseRoom? fountainRoom))
        {
            Console.WriteLine("Something went wrong and the dungeon was not configured properly. No fountain room was created during initialisation of the dungeon or it could not be found.");

            return;
        }

        while (!((FountainRoom)fountainRoom!).IsActivated)
        {
            if (dungeon.GetRoom(playerPosition) is BaseRoom room)
            {
                Console.Clear();
                Console.WriteLine(room!.Description);
                Console.WriteLine($"Your position: ");
                room.Enter(dungeon);
                dungeon.GetAdjacentRooms(room);

                var direction = InputHelper.GetChoiceFromEnum<DirectionEnum>();

                // This should be moved inside the dungeon and check if the left and right rooms arn't on a different row using modulo.
                int nextRoomIndex = direction switch
                {
                    DirectionEnum.Up => playerPosition - dungeon.XLenght,
                    DirectionEnum.Down => playerPosition + dungeon.XLenght,
                    DirectionEnum.Left => playerPosition - 1,
                    DirectionEnum.Right => playerPosition + 1,
                };

                if (dungeon.IsInBounds(nextRoomIndex))
                {
                    playerPosition = nextRoomIndex;
                }
            }    
        }
    }
}
