namespace Challenges.Part_2.Level_29;

public class WarPreperationsChallenge() : Challenge("War Preperations")
{
    public override void Run(object[]? parameters = null)
    {
        Sword sword = new(Material.Iron, Gemstone.None, 10, 2);
        Sword binariumSword = sword with { Material = Material.Binarium };
        Sword diamondGemSword = sword with { Gemstone = Gemstone.Diamond };

        Console.WriteLine(sword);
        Console.WriteLine(binariumSword);
        Console.WriteLine(diamondGemSword);
    }
}

public record Sword(Material Material, Gemstone Gemstone, int Lenght, int CrossguardWidth);

public enum Material
{
    Wood, Bronze, Iron, Steel, Binarium
}

public enum Gemstone
{
    None, Emerald, Amber, Sapphire, Diamond, Bitstone
}

