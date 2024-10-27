namespace Challenges.Part_2.Level_19;

public class VinsTrouble() : Challenge("Vin's Trouble")
{
    public override void Run(object[]? parameters = null)
    {
        Console.WriteLine("Build an arrow by giving the arrowhead type, fletching type and lenght:");

        Arrow arrow = new();

        Console.WriteLine($"This arrow costs {arrow.GetCost()} to build.");
    }
}
