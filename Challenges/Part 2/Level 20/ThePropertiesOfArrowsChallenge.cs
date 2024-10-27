using Challenges.Part_2.Level_19;

namespace Challenges.Part_2.Level_20;

public class ThePropertiesOfArrowsChallenge() : Challenge("The Properties of Arrows")
{
    public override void Run(object[]? parameters = null)
    {
        Level19 level19 = new();
        level19.Challenges.FirstOrDefault()?.Run();
    }
}
