namespace Challenges.Part_2.Level_31.Rooms;

public class BaseRoom(Coordinates coordinates, string name = "", string description = "")
{
    public Coordinates Coordinates { get; } = coordinates;
    public string Name { get; } = name;
    public string Description { get; } = description;
}
