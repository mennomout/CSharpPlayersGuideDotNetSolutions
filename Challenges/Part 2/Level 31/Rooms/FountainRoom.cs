namespace Challenges.Part_2.Level_31.Rooms;

public class FountainRoom(Coordinates coordinates) : BaseRoom(coordinates, "Fountain", "You hear the rushing waters from the Fountain of Objects. It has been reactivated!")
{
    public bool IsActivated { get; set; }
}
