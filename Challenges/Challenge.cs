namespace Challenges;

public abstract class Challenge(string name) : IChallenge
{
    public string Name { get; set; } = name;

    public abstract void Run(object[]? parameters = null);
}
