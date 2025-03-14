using Challenges.Part_2.Level_31.Rooms;
using Helpers;
using Helpers.Global_Enums;

namespace Challenges.Part_2.Level_31;

public class TheFountainOfObjectsBossBattle() : Challenge("The Fountain of Objects Game")
{
    public override void Run(object[]? parameters = null)
    {
        Dungeon dungeon = new(4, 4);
        Coordinates playerCoordinates = new(0, 0);
        
        if (!dungeon.TryFindRoomByType(typeof(FountainRoom), out BaseRoom? fountainRoom))
        {
            Console.WriteLine("Something went wrong and the dungeon was not configured properly. No fountain room was created during initialisation of the dungeon or it could not be found.");

            return;
        }

        while (!((FountainRoom)fountainRoom!).IsActivated)
        {
            if (dungeon.TryFindRoomByCoordinates(playerCoordinates, out BaseRoom? room))
            {
                Console.Clear();
                Console.WriteLine(room!.Description);
                Console.WriteLine($"Your position: ({playerCoordinates.X}, {playerCoordinates.Y})");

                var direction = InputHelper.GetChoiceFromEnum<DirectionEnum>();

                Coordinates nextRoomCoordinates = direction switch
                {
                    DirectionEnum.Up => new(playerCoordinates.X, playerCoordinates.Y - 1),
                    DirectionEnum.Down => new(playerCoordinates.X, playerCoordinates.Y + 1),
                    DirectionEnum.Left => new(playerCoordinates.X - 1, playerCoordinates.Y),
                    DirectionEnum.Right => new(playerCoordinates.X + 1, playerCoordinates.Y),
                };

                if (dungeon.IsValidCoordinate(nextRoomCoordinates))
                {
                    playerCoordinates = nextRoomCoordinates;
                    ((FountainRoom)fountainRoom).IsActivated = fountainRoom.Coordinates == playerCoordinates;
                }
            }    
        }
    }
}
