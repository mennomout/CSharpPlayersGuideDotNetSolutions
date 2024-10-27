using Challenges;

namespace ChallengesPart1Level3;

public class Level3 : BaseLevel
{
    public Level3() : base(3, "Hello World: Your First Program", [
        new HelloWorldChallenge(),
        new WhatComesNextChallange(),
        new TheMakingsOfAProgrammerChallenge(),
        new ConsolasAndTelimChallenge()])
    {
    }
}
