using Challenges;

namespace ChallengesPart1Level4;

public class TheThingNamer3000Challenge() : Challenge("The Thing Namer 3000")
{
    public override void Run(object[]? parameters = null)
    {
        Console.WriteLine("What kind of thing are we talking about?");
        string? typeOfThing = Console.ReadLine();
        Console.WriteLine("How would you describe it? Big? Azure? Tattered?");
        string? descriptionOfThing = Console.ReadLine();
        string? doomAdjective = "of Doom";
        string? version = "3000";
        Console.WriteLine("The " + descriptionOfThing + " " + typeOfThing + doomAdjective + " " + version + "!");
    }
}
