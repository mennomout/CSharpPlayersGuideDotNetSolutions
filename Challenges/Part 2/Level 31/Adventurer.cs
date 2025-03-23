using Helpers;
using Helpers.Global_Enums;

namespace Challenges.Part_2.Level_31;

public class Adventurer
{
    public string Name => "Adventurer";
    public bool IsDeath { get; private set; }

    public int GetNextRoomByMoveDirection(Dungeon dungeon)
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
