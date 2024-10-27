namespace Challenges.Part_2.Level_24;

public class ThePointChallenge() : Challenge("The Point")
{
    public override void Run(object[]? parameters = null)
    {
        Point pointOne = new(2, 3);
        Point pointTwo = new(-4, 0);

        Console.WriteLine($"({pointOne.X}, {pointOne.Y})");
        Console.WriteLine($"({pointTwo.X}, {pointTwo.Y})");

        Console.WriteLine("They were mutable until I read this question. I don't think either option is bad but in the current program a point does not need to have mutable X and Y values and therefore I've made them immutable.");
    }
}
