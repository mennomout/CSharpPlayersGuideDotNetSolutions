namespace Challenges.Part_2.Level_31.Rooms;

public class MaelstromRoom() : BaseRoom("Maelstrom room", "You are blown away.")
{
    public override void Enter(Dungeon dungeon)
    {
        dungeon.TryMovePlayer(Random.Shared.Next(dungeon.XLenght));
    }
}
