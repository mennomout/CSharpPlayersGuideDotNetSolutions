using Challenges;

namespace ChallengesPart1Level6;

public class Level6 : BaseLevel
{
    public Level6() : base(6, "Variables", [new TheVariableShopChallenge(), new TypeSystemKnowledgeCheck(), 
                                            new TheVariableShopReturnsChallenge()])
    {
    }
}
