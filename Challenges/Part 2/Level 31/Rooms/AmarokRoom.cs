namespace Challenges.Part_2.Level_31.Rooms;

public class AmarokRoom() : BaseRoom("Amarok", "You enter a room with a giant, rotting, wolf-like creature and...")
{
    public bool IsDeath { get; private set; }

    public override void Enter(Dungeon dungeon, Adventurer adventurer)
    {
        if (IsDeath)
        {
            Console.WriteLine("find it's corpse. You retrieve the arrow.");
        }
        else
        {
            Console.WriteLine("You are torn appart by it.");
            adventurer.Kill();
        }
    }

    public void Hit() => IsDeath = true;
}
