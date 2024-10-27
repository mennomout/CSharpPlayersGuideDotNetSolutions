namespace Challenges.Part_1.Level_13;

public class CountdownChallenge() : Challenge("Countdown")
{
    public override void Run(object[]? parameters = null)
    {
        CountDownToZero(10);
    }

    public void CountDownToZero(int startingNumber)
    {
        Console.WriteLine(startingNumber);

        if (startingNumber > 0) CountDownToZero(startingNumber -= 1);
    }
}
