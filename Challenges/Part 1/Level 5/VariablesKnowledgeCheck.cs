using Challenges;

namespace ChallengesPart1Level5;

public class VariablesKnowledgeCheck() : Challenge("Variables")
{
    public override void Run(object[]? parameters = null)
    {
        Console.WriteLine("1. A type, name and value");
        Console.WriteLine("2. true");
        Console.WriteLine("3. No, you can reassign its value though");
        Console.WriteLine("4. I had to peak the solution for this one. I always use common naming conventions and forgot what characters are not allowed in a variable. " +
            "Anyway, the legal names are: 'answer', 'value1', 'delete_me', 'PI'");
    }
}
