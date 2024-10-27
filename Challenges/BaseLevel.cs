namespace Challenges;

public class BaseLevel(int id, string name, List<Challenge> challenges)
{
    public List<Challenge> Challenges { get; set; } = challenges;
    public string? Name { get; set; } = name;
    public int Id { get; set; } = id;
}
