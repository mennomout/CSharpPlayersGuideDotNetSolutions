using Helpers;
using Helpers.Global_Enums;

namespace Challenges.Part_2.Level_31;

public class Adventurer
{
    public string Name => "Adventurer";
    public bool IsDeath { get; private set; }
    public int Position { get; private set; }
    public int ArrowCount { get; private set; } = 5;

    public void Shoot() => ArrowCount--;
    public void RetrieveArrow() => ArrowCount++;
    public void Kill() => IsDeath = true;
    public void Move(int newPosition) => Position = newPosition;
}
