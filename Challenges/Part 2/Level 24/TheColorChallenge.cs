namespace Challenges.Part_2.Level_24;

public class TheColorChallenge() : Challenge("The Color")
{
    public override void Run(object[]? parameters = null)
    {
        Color color = new(122, 232, 232);
        Color red = Color.GetRed();

        Console.WriteLine($"{color.R}, {color.G}, {color.B}");
        Console.WriteLine($"{red.R}, {red.G}, {red.B}");
    }
}
