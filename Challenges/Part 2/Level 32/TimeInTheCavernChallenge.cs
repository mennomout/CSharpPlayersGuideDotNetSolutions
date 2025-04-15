using Challenges.Part_2.Level_31;

namespace Challenges.Part_2.Level_32;

public class TimeInTheCavernChallenge() : Challenge("Time in the Cavern")
{
    public override void Run(object[]? parameters = null)
    {
        var startTime = DateTime.Now;
        var fountainChallenge = new TheFountainOfObjectsBossBattle();
        fountainChallenge.Run();
        var timeSpan = DateTime.Now - startTime;

        Console.WriteLine($"You played the game for: {timeSpan.Hours} hours, {timeSpan.Minutes} minutes, {timeSpan.Seconds} secondes.");
    }
}
