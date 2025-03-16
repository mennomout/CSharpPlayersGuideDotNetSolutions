namespace Challenges.Part_2.Level_31.Rooms;

public class FountainRoom() : BaseRoom("Fountain", "You hear the rushing waters from the Fountain of Objects. It has been reactivated!")
{
    public bool IsActivated { get; private set; }

    public override void Enter(Dungeon dungeon)
    {
        IsActivated = true;
    }
}
