namespace Challenges.Part_2.Level_31.Rooms;

public class MaelstromRoom() : BaseRoom("Maelstrom room", "You are swept away by a Maelstrom.")
{
    public override void Enter(Dungeon dungeon, Adventurer adventurer)
    {
        adventurer.Move(Random.Shared.Next(dungeon.Rooms.Count));
        Console.WriteLine($"Your new position: {dungeon.GetCoordinates(adventurer.Position)}");
        Console.WriteLine(dungeon.Rooms[adventurer.Position].Description);
        dungeon.Rooms[adventurer.Position].Enter(dungeon, adventurer);

        var room = dungeon.Rooms.IndexOf(this);
        dungeon.Rooms[room] = new EmptyRoom();
        dungeon.SeedRoom(new MaelstromRoom());
    }
}
