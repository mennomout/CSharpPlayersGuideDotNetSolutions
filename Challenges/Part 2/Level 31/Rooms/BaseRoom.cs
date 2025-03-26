namespace Challenges.Part_2.Level_31.Rooms;

public abstract class BaseRoom(string name = "", string description = "") : IRoom
{
    public string Name { get; } = name;
    public string Description { get; } = description;

    public abstract void Enter(Dungeon dungeon, Adventurer adventurer);
}
