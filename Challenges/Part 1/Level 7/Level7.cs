using Challenges;
using Challenges.Part_1.Level_7;

namespace ChallengesPart1Level7;

public class Level7 : BaseLevel
{
    public Level7() : base(7, "Variables", [new TheTriangleFarmerChallenge(),
                                            new TheFourSistersAndTheDuckbearChallenge(),
                                            new TheDominionOfKingsChallenge()])
    {
    }
}
